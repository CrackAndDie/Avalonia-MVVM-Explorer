using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AvaloniaMVVMExplorer.ViewModels.Base;
using AvaloniaMVVMExplorer.ViewModels.Commands;
using AvaloniaMVVMExplorer.ViewModels.FileViewModels;
using AvaloniaMVVMExplorer.ViewModels.FileViewModels.Base;

namespace AvaloniaMVVMExplorer.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Properties
        private string? currentFilePath;
        public string? CurrentFilePath
        {
            get { return currentFilePath; } 
            set { currentFilePath = value; OnPropertyChanged(); }
        }

        private ObservableCollection<FileEntityViewModel>? directoriesAndFiles;
        public ObservableCollection<FileEntityViewModel>? DirectoriesAndFiles
        {
            get { return directoriesAndFiles; }
            set { directoriesAndFiles = value; OnPropertyChanged(); }
        }

        private FileEntityViewModel? selectedFileEntity;
        public FileEntityViewModel? SelectedFileEntity
        {
            get { return selectedFileEntity; }
            set { selectedFileEntity = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public ICommand OpenCommand { get; }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            DirectoriesAndFiles = new ObservableCollection<FileEntityViewModel>();

            OpenCommand = new DelegateCommand(Open);

            foreach (var logicalDrive in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
            }
        }
        #endregion

        #region CommandMethods
        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                CurrentFilePath = directoryViewModel.FullName;

                DirectoriesAndFiles?.Clear();

                var directoryInfo = new DirectoryInfo(CurrentFilePath ?? "");

                foreach (var directory in directoryInfo.GetDirectories()) 
                {
                    DirectoriesAndFiles?.Add(new DirectoryViewModel(directory));
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    DirectoriesAndFiles?.Add(new FileViewModel(file));
                }
            }
        }
        #endregion
    }
}