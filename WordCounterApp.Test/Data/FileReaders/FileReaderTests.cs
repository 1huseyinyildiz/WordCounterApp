using WordCounterApp.Data.FileReaders;

namespace WordCounterApp.Test.Data.FileReaders
{
    [TestFixture]
    public class FileReaderTests
    {
        private FileReader _fileReader;

        [SetUp]
        public void Setup()
        {
            _fileReader = new FileReader();
        }

        [Test]
        public void ReadFile_ValidFile_ReturnsContent()
        {
            string[] filePaths = { 
                @"C:\Projects\WordCounterApp\WordCounterApp.Tests\TestData\testFile1.txt" , 
                @"C:\Projects\WordCounterApp\WordCounterApp.Tests\TestData\testFile2.txt" };
            var results = _fileReader.ReadFiles(filePaths);
            Assert.IsNotNull(results);

        }

        [Test]
        public void ReadFile_InvalidFile_ThrowsFileNotFoundException()
        {
            string[] invalidFilePaths = { @"C:\Projects\WordCounterApp\WordCounterApp.Tests\TestData\nonexistent.txt" };
            var ex = Assert.Throws<FileNotFoundException>(() => _fileReader.ReadFiles(invalidFilePaths));

            Assert.That(ex.Message, Does.Contain("File not found:"));
        }
    }
}
