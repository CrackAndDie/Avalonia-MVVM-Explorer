using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaMVVMExplorer.ViewModels.FileViewModels.Base;

namespace AvaloniaMVVMExplorer.ViewModels.FileViewModels
{
    internal sealed class FileViewModel : FileEntityViewModel
    {
        public FileViewModel(string fileName) : base(fileName) 
        {
            FullName = fileName;
        }
        public FileViewModel(FileInfo fileInfo) : base(fileInfo.Name) 
        {
            FullName = fileInfo.FullName;
        }
    }
}
