using AvaloniaMVVMExplorer.ViewModels.Commands;
using AvaloniaMVVMExplorer.ViewModels.FileViewModels.Base;
using AvaloniaMVVMExplorer.ViewModels.FileViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AvaloniaMVVMExplorer.ViewModels.Base;

namespace AvaloniaMVVMExplorer.ViewModels
{
    internal class DirectoryTabItemViewModel : ViewModelBase
    {
        #region Properties
        private string? currentFilePath;
        public string? CurrentFilePath
        {
            get { return currentFilePath; }
            set { currentFilePath = value; OnPropertyChanged(); }
        }

        private string? name = "Мой компьютер";
        public string? Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private ObservableCollection<FileEntityViewModel>? directoriesAndFiles = new ObservableCollection<FileEntityViewModel>();
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

        #region Events
        public event EventHandler TabClose;
        #endregion

        #region Commands
        public ICommand OpenCommand { get; }
        public ICommand CloseCommand { get; }
        #endregion

        #region Constructor
        public DirectoryTabItemViewModel()
        {
            OpenCommand = new DelegateCommand(Open);
            CloseCommand = new DelegateCommand(Close);

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
                Name = directoryViewModel.Name;
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

        private void Close(object parameter)
        {
            TabClose?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
