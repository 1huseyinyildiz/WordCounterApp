using System;
using System.IO;
using WordCounterApp.Data.FileReaders;
using WordCounterApp.Core.Interfaces;
using WordCounterApp.Services;
using WordCounterApp.Core.Models;

namespace WordCounterApp.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string testDataFolder = @"C:\Projects\WordCounterApp\WordCounterApp.Test\TestData";

                string[] filePaths = {
                Path.Combine(testDataFolder, "testFile1.txt"),
                Path.Combine(testDataFolder, "testFile2.txt")
               };

                var fileReader = new FileReader();
                IWordCountService wordCountService = new WordCountService(fileReader);

                var results = wordCountService.CountWords(filePaths);

                foreach (var result in results)
                {
                    Console.WriteLine($"{result.Count}: {result.Word}");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message} - {ErrorConst.FileNotFoundException}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message} - {ErrorConst.DirectoryNotFoundException}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: {ex.Message} - {ErrorConst.IOException}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} - {ErrorConst.DefaultException}");
            }
        }
    }
}
