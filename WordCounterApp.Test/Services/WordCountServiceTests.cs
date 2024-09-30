using Moq;
using WordCounterApp.Core.Interfaces;
using WordCounterApp.Core.Models;
using WordCounterApp.Services;
namespace WordCounterApp.Test.Services
{
    [TestFixture]
    public class WordCountServiceTests
    {
        private WordCountService _wordCountService;
        private Mock<IFileReader> _fileReaderMock; 


        [SetUp]
        public void Setup()
        {
            _fileReaderMock = new Mock<IFileReader>();
            _wordCountService = new WordCountService(_fileReaderMock.Object);
        }
        [Test]
        public void CountWords_ValidFiles_ReturnsCorrectWordCount()
        {
            string[] filePaths = {
                @"C:\Projects\WordCounterApp\WordCounterApp.Tests\TestData\testFile1.txt",
                @"C:\Projects\WordCounterApp\WordCounterApp.Tests\TestData\testFile2.txt"
            };

            var expectedCounts = new List<WordCount>
            {
                new WordCount("Go", 1),
                new WordCount("do", 2),
                new WordCount("that", 2),
                new WordCount("thing", 1),
                new WordCount("you", 1),
                new WordCount("so", 1),
                new WordCount("well", 2),
                new WordCount("I", 1),
                new WordCount("play", 1),
                new WordCount("football", 1)
            };

            var fileContents = new List<string>
            {
                "Go do that thing that you do so well",
                "I play football well"
            };

            _fileReaderMock.Setup(fr => fr.ReadFiles(filePaths)).Returns(fileContents);

            var results = _wordCountService.CountWords(filePaths);
            Assert.AreEqual(expectedCounts.Count, results.Count);

            foreach (var expected in expectedCounts)
            {
                var actual = results.Find(r => r.Word == expected.Word);
                Assert.IsNotNull(actual, $"Expected word '{expected.Word}' not found.");
                Assert.AreEqual(expected.Count, actual.Count);
            }
        }

        [Test]
        public void CountWords_EmptyFileList_ReturnsEmptyList()
        {
            string[] filePaths = { };
            var results = _wordCountService.CountWords(filePaths);
            Assert.IsEmpty(results);
        }
    }
}
