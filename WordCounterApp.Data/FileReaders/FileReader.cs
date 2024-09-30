using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounterApp.Core.Interfaces;

namespace WordCounterApp.Data.FileReaders
{
    public class FileReader : IFileReader
    {
        public List<string> ReadFiles(string[] filePaths)
        {
            var contents = new List<string>();

            foreach (var filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"File not found: {filePath}");
                }

                string content = File.ReadAllText(filePath);
                contents.Add(content);
            }
            return contents;
        }
    }
}
