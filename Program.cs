using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SeparateFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var mainPath = "";
            var partsPath = "";
            var howManyFiles = "";

            var objMainPath = new FileSplit(mainPath);
            var objPartsPath = new FileSplit(partsPath, howManyFiles);

            mainPath = objMainPath.MainFilePath;
            partsPath = objPartsPath.PartsDirectory;
            howManyFiles = objPartsPath.HowManyFiles;
            objMainPath.Split(mainPath, howManyFiles, partsPath);

            stopWatch.Stop();
            Console.WriteLine($"Time Spent (s): {stopWatch.Elapsed.TotalSeconds:F2}");
        }
    }
}
