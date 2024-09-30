using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounterApp.Core.Models;

namespace WordCounterApp.Core.Interfaces
{
    public interface IWordCountService
    {
        List<WordCount> CountWords(string[] filePaths);
    }
}
