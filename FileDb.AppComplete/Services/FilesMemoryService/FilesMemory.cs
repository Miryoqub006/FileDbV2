using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDb.AppComplete.Services.FilesMemoryService
{
    internal class FilesMemory : IFilesMemory
    {
        public long GetFilesSize(DirectoryInfo directoryInfo)
        {
            long totalSize = 0;

            FileInfo[] filesInfo = directoryInfo.GetFiles();

            foreach (FileInfo fileInfo in filesInfo)
            {
                totalSize += fileInfo.Length;
            }

            DirectoryInfo[] subfolders = directoryInfo.GetDirectories();
            foreach (DirectoryInfo dirInfo in subfolders)
            {
                totalSize += GetFilesSize(dirInfo);
            }

            return totalSize;
        }
    }
}
