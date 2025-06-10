using System;

namespace EventDelegateSignatures
{
    internal class FileFoundArgs : EventArgs
    {
        public string FoundFile { get; }
        public bool CancelRequested { get; set; }

        public FileFoundArgs(string fileName) => FoundFile = fileName;
    }
}
