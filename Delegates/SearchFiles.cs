using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class SearchFiles
    {
        public event EventHandler<FileArgs>? FileFound;

        public bool CancelSearch { get; set; }

        public void CancelRequest()
        {
            CancelSearch = true;
        }
        
        public void Searching(string directoryPath)
        {
            if(string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
            {
                throw new ArgumentNullException("Folder not exists");
            }
            CancelSearch = false;
            var files = Directory.GetFiles(directoryPath);
            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    FileFound?.Invoke(file, new FileArgs(file));
                }
                if (CancelSearch) break;
            }
        }
    }
}
