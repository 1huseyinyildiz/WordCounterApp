using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterApp.Core.Interfaces
{
    public interface IFileReader
    {
        List<string> ReadFiles(string[] filePaths);
    }
}
