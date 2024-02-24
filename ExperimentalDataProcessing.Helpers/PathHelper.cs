using System;
using System.IO;
using System.Linq;

namespace ExperimentalDataProcessing.Helpers
{
    public static class PathHelper
    {
        public static string GetSolutionFolderPath()
        {
            // Get the current directory where the executable is located
            string currentDirectory = Directory.GetCurrentDirectory();

            // Navigate up to the solution folder (assuming solution folder contains .sln file)
            string solutionFolderPath = currentDirectory;
            //Directory.EnumerateFiles(solutionFolderPath, "*.sln", SearchOption.AllDirectories).FirstOrDefault() != null;
            
            while (Directory.EnumerateFiles(solutionFolderPath, "*.sln", SearchOption.AllDirectories).FirstOrDefault() is null)
            {
                solutionFolderPath = Directory.GetParent(solutionFolderPath)?.FullName;
                if (solutionFolderPath is null)
                {
                    throw new InvalidOperationException("Solution folder not found.");
                }
            }

            return solutionFolderPath;
        }
    }
}