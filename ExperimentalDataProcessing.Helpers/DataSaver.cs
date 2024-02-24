using System;
using System.Collections.Generic;
using System.IO;

namespace ExperimentalDataProcessing.Helpers
{
    public class DataSaver
    {
        public static void SaveDataToFile(IEnumerable<double> xs, string fileName, string fileExtension = ".txt",
            bool hasDateTime = true, string folderPath = null)
        {
            if (folderPath is null)
            {
                var solutionFolderPath = PathHelper.GetSolutionFolderPath();
                folderPath = Path.Combine(solutionFolderPath, "DataFiles");
            }

            var fullFileName = fileName;

            if (hasDateTime)
            {
                var currentDateTime = DateTime.Now;
                var formattedDateTime = currentDateTime.ToString("yyyyMMdd_HHmmss");
                fullFileName += $"_{formattedDateTime}";
            }

            fullFileName += fileExtension;

            var filePath = Path.Combine(folderPath, fullFileName);

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var x in xs)
                {
                    writer.WriteLine($"{x}");
                }
            }
        }
    }
}