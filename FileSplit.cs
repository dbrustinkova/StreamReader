using System.Collections.Generic;
using System.IO;

namespace SeparateFiles
{
    public class FileSplit
    {
        private string mainPath;
        private string partsPath;
        private string howManyFiles;
        private int numberOfFiles = 2;

        public FileSplit(string mainFilePath)
        {
            MainFilePath = mainFilePath;
        }

        public FileSplit(string partsDirectory, string howManyFiles)
        {
            PartsDirectory = partsDirectory;
            HowManyFiles = howManyFiles;
        }

        public string MainFilePath
        {
            get => mainPath;
            set
            {
                mainPath = UserMessages.PromptUserForAnswer(UserMessages.AskWhichFile);
            }
        }

        public string PartsDirectory
        {
            get => partsPath;
            set
            {
                partsPath = UserMessages.PromptUserForAnswer(UserMessages.AskWhereToSave);
            }
        }

        public string HowManyFiles
        {
            get => howManyFiles;
            set
            {
                howManyFiles = UserMessages.PromptUserForAnswer(UserMessages.AskHowManyFiles);
            }
        }

        private void Read(string mainPath, string howManyFiles, string partsPath)
        {
            var lines = new List<string>();

            using (StreamReader sr = new StreamReader(mainPath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            if (lines.Count > 2)
            {
                numberOfFiles = int.TryParse(howManyFiles, out numberOfFiles) ? numberOfFiles : 2;
            }

            Write(lines, partsPath);
        }

        private void Write(List<string> lines, string partsPath)
        {            
            var fileCounter = 1;
            var linesPerFile = lines.Count / numberOfFiles;
            var currEndLine = linesPerFile;

            var stream = new StreamWriter($"{partsPath}/{fileCounter}. file.csv");

            for (int row = 0; row < lines.Count; row++)
            {
                stream.WriteLine(lines[row]);

                if (row == currEndLine - 1 && fileCounter < numberOfFiles)
                {
                    fileCounter++;

                    if (fileCounter == numberOfFiles)
                    {
                        currEndLine = lines.Count;
                    }
                    else
                    {
                        currEndLine += linesPerFile;
                    }
                    stream.Close();
                    stream = new StreamWriter($"{partsPath}/{fileCounter}. file.csv");
                }
            }
            stream.Close();
        }

        public void Split(string mainPath, string howManyFiles, string partsPath)
        {
            Read(mainPath, howManyFiles, partsPath);
        }
    }
}
