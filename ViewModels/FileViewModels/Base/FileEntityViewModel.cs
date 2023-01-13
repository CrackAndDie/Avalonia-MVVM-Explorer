using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaMVVMExplorer.ViewModels.Base;

namespace AvaloniaMVVMExplorer.ViewModels.FileViewModels.Base
{
    internal abstract class FileEntityViewModel : ViewModelBase
    {
        public string Name { get; }
        public string? FullName { get; set; }

        protected FileEntityViewModel(string directoryName)
        {
            Name = directoryName;
        }
    }
}
