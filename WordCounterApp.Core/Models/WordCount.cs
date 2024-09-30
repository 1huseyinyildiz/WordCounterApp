using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterApp.Core.Models
{
    public class WordCount
    {
        public string Word { get; set; }
        public int Count { get; set; }

        public WordCount(string word, int count)
        {
            Word = word;
            Count = count;
        }
    }
}
