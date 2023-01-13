using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaMVVMExplorer.ViewModels.FileViewModels.Base;

namespace AvaloniaMVVMExplorer.ViewModels.FileViewModels
{
    internal sealed class DirectoryViewModel : FileEntityViewModel
    {
        public DirectoryViewModel(string directoryName) : base(directoryName)
        {
            FullName = directoryName;
        }
        public DirectoryViewModel(DirectoryInfo directoryInfo) : base(directoryInfo.Name) 
        {
            FullName = directoryInfo.FullName;
        }
    }
}
