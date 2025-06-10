using System;
using System.IO;

namespace EventDelegateSignatures
{
    internal class FileSearcher
    {
        public event EventHandler<FileFoundArgs> FileFound;

        internal event EventHandler<SearchDirectoryArgs> DirectoryChanged
        {
            add { _directoryChanged += value; }
            remove { _directoryChanged -= value; }
        }

        private EventHandler<SearchDirectoryArgs> _directoryChanged;

        public void Search(string directory, string searchPattern, bool searchSubDirs = false)
        {
            if (searchSubDirs)
            {
                var allDirectories = Directory.GetDirectories(directory, "*.*", SearchOption.AllDirectories);
                var completedDirs = 0;
                var totalDirs = allDirectories.Length + 1;
                foreach (var dir in allDirectories)
                {
                    _directoryChanged?.Invoke(this, new SearchDirectoryArgs(dir, totalDirs, completedDirs++));

                    SearchDirectory(dir, searchPattern);
                }
                _directoryChanged?.Invoke(this, new SearchDirectoryArgs(directory, totalDirs, completedDirs++));
                SearchDirectory(directory, searchPattern);
            }
            else
            {
                SearchDirectory(directory, searchPattern);
            }
        }

        private void SearchDirectory(string directory, string searchPattern)
        {
            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                var args = new FileFoundArgs(file);
                FileFound?.Invoke(this, args);
                if (args.CancelRequested)
                    break;
            }
        }
    }
}
