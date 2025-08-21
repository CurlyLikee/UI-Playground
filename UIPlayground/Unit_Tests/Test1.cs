using UIPlayground;

namespace Unit_Tests
{
    [TestClass]
    public class QuoteManagerTests
    {
        private QuoteManager _quoteManager = new QuoteManager();

        [TestInitialize]
        public void Setup()
        {
            _quoteManager = new QuoteManager();
        }

        [TestMethod]
        public void GetRandomQuote_ShouldReturnNonNullOrEmptyQuote()
        {
            try
            {
                var quote = _quoteManager.GetRandomQuote();
                Console.WriteLine($"Received quote: '{quote}'");
                Assert.IsFalse(string.IsNullOrEmpty(quote), "Quote should not be null or empty.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetRandomQuote test: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        [TestMethod]
        public void GetRandomQuote_ShouldReturnQuoteFromList()
        {
            try
            {
                var validQuotes = new[]
                {
                    "...you must remember that the journey itself has meaning. ...The destination is not everything.",
                    "If you can change something, change it. If you can't, don't waste time thinking about it",
                    "Never stop searching, even if only for a brief flash of light. If nothing else, we have the present moment"
                };

                var quote = _quoteManager.GetRandomQuote();
                Console.WriteLine($"Received quote: '{quote}'");
                Console.WriteLine($"Valid quotes count: {validQuotes.Length}");

                CollectionAssert.Contains(validQuotes, quote, "Quote should be from the predefined list.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetRandomQuote_ShouldReturnQuoteFromList test: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }
    }

    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void Log_ShouldAddEntry()
        {
            try
            {
                var logger = new Logger("test_log.json");
                Console.WriteLine("Logger created successfully");

                logger.Log("Test message");
                Console.WriteLine("Message logged");

                Console.WriteLine($"Entries count: {logger.Entries.Count}");
                if (logger.Entries.Any())
                {
                    Console.WriteLine($"First entry message: '{logger.Entries.First().Message}'");
                }

                Assert.IsTrue(logger.Entries.Any(e => e.Message == "Test message"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Log_ShouldAddEntry test: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        [TestMethod]
        public void SaveToJson_ShouldCreateFile()
        {
            try
            {
                var logger = new Logger("test_output.json");
                Console.WriteLine("Logger created for file test");

                logger.Log("Saving test");
                Console.WriteLine("Message logged for file test");

                logger.SaveToJson();
                Console.WriteLine("SaveToJson called");

                bool fileExists = File.Exists("test_output.json");
                Console.WriteLine($"File exists: {fileExists}");

                if (fileExists)
                {
                    string content = File.ReadAllText("test_output.json");
                    Console.WriteLine($"File content: {content}");
                }

                Assert.IsTrue(fileExists);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in SaveToJson_ShouldCreateFile test: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                if (File.Exists("test_log.json"))
                {
                    File.Delete("test_log.json");
                    Console.WriteLine("Deleted test_log.json");
                }
                if (File.Exists("test_output.json"))
                {
                    File.Delete("test_output.json");
                    Console.WriteLine("Deleted test_output.json");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in cleanup: {ex.Message}");
            }
        }
    }
}