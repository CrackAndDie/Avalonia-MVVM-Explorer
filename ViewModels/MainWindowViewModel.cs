using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AvaloniaMVVMExplorer.ViewModels.Base;
using System.Xml.Linq;
using AvaloniaMVVMExplorer.ViewModels.FileViewModels.Base;
using System.Linq;
using AvaloniaMVVMExplorer.ViewModels.Commands;

namespace AvaloniaMVVMExplorer.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Properties
        private ObservableCollection<DirectoryTabItemViewModel> directoryTabItems = new ObservableCollection<DirectoryTabItemViewModel>();
        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems
        {
            get { return directoryTabItems; }
            set { directoryTabItems = value; OnPropertyChanged(); }
        }

        private DirectoryTabItemViewModel currentDirectoryTabItem;
        public DirectoryTabItemViewModel CurrentDirectoryTabItem
        {
            get { return currentDirectoryTabItem; }
            set { currentDirectoryTabItem = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public ICommand AddTabItemCommand { get; }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAddTabItem);
            AddTabItemViewModel();
            AddTabItemViewModel();
            AddTabItemViewModel();
        }
        #endregion

        #region CommandMethods
        private void OnAddTabItem(object parameter)
        {
            AddTabItemViewModel();
        }
        #endregion

        #region PrivateMethods
        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();
            vm.TabClose += OnTabClose;
            DirectoryTabItems.Add(vm);
            CurrentDirectoryTabItem = vm;
        }

        private void OnTabClose(object sender, EventArgs args)
        {
            if (sender is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            directoryTabItemViewModel.TabClose -= OnTabClose;
            DirectoryTabItems.Remove(directoryTabItemViewModel);
        }
        #endregion
    }
}