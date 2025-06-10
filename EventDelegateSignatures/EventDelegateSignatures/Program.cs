using System;

namespace EventDelegateSignatures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileLister = new FileSearcher();
            int filesFound = 0;

            EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.FoundFile);
                filesFound++;
            };

            fileLister.FileFound += onFileFound;

            fileLister.DirectoryChanged += (sender, eventArgs) =>
            {
                Console.Write($"Entering '{eventArgs.CurrentSearchDirectory}'.");
                Console.WriteLine($" {eventArgs.CompletedDirs} of {eventArgs.TotalDirs} completed...");
            };

            fileLister.Search(@"C:\SomeDirectory", "*.exe", searchSubDirs: true);

            fileLister.FileFound -= onFileFound;

        }
    }
}
