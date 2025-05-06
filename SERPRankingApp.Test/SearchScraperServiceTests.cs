using SERPRankingApp.Infrastructure.SearchScraper;

namespace SERPRankingApp.Test
{
    public class SearchScraperServiceTests
    {
        private readonly SearchScraperService _service;
        private string targetURL = "example.com";

        public SearchScraperServiceTests()
        {
            _service = new SearchScraperService();
        }

        [Fact]
        public async Task ScrapeGoogleForRankingsAsync_EmptySearchTerm_ThrowsArgumentException()
        {
            string searchTerm = "";

            await Assert.ThrowsAsync<ArgumentException>(() => _service.ScrapeGoogleForRankingsAsync(searchTerm, targetURL));
        }

        [Fact]
        public async Task ScrapeHTMLFileForRankingsAsync_ValidFileAndTargetURL_ReturnsRankings()
        {
            string filePath = "test.html";
            string htmlContent = "<!DOCTYPE html><html><body><a href='http://example.com'>Example</a></body></html>";

            await File.WriteAllTextAsync(filePath, htmlContent);

            try
            {
                var result = await _service.ScrapeHTMLFileForRankingsAsync(targetURL, filePath);

                Assert.NotNull(result);
                Assert.Contains(1, result);
                Assert.Single(result);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [Fact]
        public async Task ScrapeHTMLFileForRankingsAsync_InvalidFilePath_ThrowsFileNotFoundException()
        {
            string filePath = "nonexistent.html";

            await Assert.ThrowsAsync<FileNotFoundException>(() => _service.ScrapeHTMLFileForRankingsAsync(targetURL, filePath));
        }

        [Fact]
        public async Task ScrapeHTMLFileForRankingsAsync_InvalidHTMLContent_ThrowsInvalidOperationException()
        {
            string filePath = "test_invalid.html";
            string invalidContent = "This is not valid HTML";

            await File.WriteAllTextAsync(filePath, invalidContent);

            try
            {
                await Assert.ThrowsAsync<InvalidOperationException>(() => _service.ScrapeHTMLFileForRankingsAsync(targetURL, filePath));
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}

