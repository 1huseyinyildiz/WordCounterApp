using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounterApp.Core.Interfaces;
using WordCounterApp.Core.Models;
namespace WordCounterApp.Services
{
    public class WordCountService : IWordCountService
    {
        private readonly IFileReader _fileReader;

        public WordCountService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public List<WordCount> CountWords(string[] filePaths)
        {
            if (filePaths == null || filePaths.Length == 0)
            {
                return new List<WordCount>();
            }

            var contents = _fileReader.ReadFiles(filePaths);
            var wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            if (contents.Count != null && contents.Count > 0)
            {
                foreach (var content in contents)
                {
                    var words = content.Split(ConstValues.speacialCharacters, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                        else
                        {
                            wordCounts[word] = 1;
                        }
                    }
                }
            }
            // Sonuçları WordCount nesnelerine dönüştür
            return wordCounts.Select(kvp => new WordCount(kvp.Key, kvp.Value)).ToList();
        }
    }
}
