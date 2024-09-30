using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterApp.Core.Models
{
    public static class ErrorConst
    {
        public static readonly string FileNotFoundException = "File Not Found!";
        public static readonly string IOException = "IO  Exception!";
        public static readonly string DirectoryNotFoundException = "Directory Not Found Exception!";
        public static readonly string DefaultException = "Unknown Exception!";
    }
}
