using HtmlAgilityPack;
using SERPRankingApp.Application.Contracts;
using System.Net;

namespace SERPRankingApp.Infrastructure.SearchScraper
{
    public class SearchScraperService : ISearchScraperService
    {
        public List<int> ScrapeHTMLDoc(HtmlDocument doc, string targetURL)
        {
            var results = new List<int>();
            var anchors = doc.DocumentNode.SelectNodes("//a[@href]");
            if (anchors == null)
                return new List<int> { 0 }; 

            int rank = 1;
            foreach (var a in anchors)
            {
                var hrefValue = WebUtility.HtmlDecode(a.GetAttributeValue("href", ""));
                if (hrefValue.Contains(targetURL, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(rank);
                }
                rank++;
            }

            if (!results.Any())
            {
                results.Add(0);
            }

            return results;
        }

        public void ValidateSearchResult(string html)
        {
            if (html.Contains("unusual traffic", StringComparison.OrdinalIgnoreCase) ||
            html.Contains("Our systems have detected unusual traffic", StringComparison.OrdinalIgnoreCase) ||
            html.Contains("captcha", StringComparison.OrdinalIgnoreCase) || html.Contains("Before you continue to Google", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Google has blocked the request. The response indicates unusual traffic or CAPTCHA.");
            }
        }

        public async Task<List<int>> ScrapeGoogleForRankingsAsync(string searchTerm, string targetURL)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("Search term cannot be null or empty.", nameof(searchTerm));

            string webSearchTerm = searchTerm.Replace(" ", "+");
            string searchUrl = $"https://www.google.co.uk/search?num=100&q={WebUtility.UrlEncode(webSearchTerm)}";

            using var handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            handler.CookieContainer.Add(new Uri("https://www.google.co.uk"), new Cookie("CONSENT", "YES+1"));

            using var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-GB,en;q=0.9");

            string html;

            try
            {
                html = await client.GetStringAsync(searchUrl);
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Failed to fetch search engine results.", ex);
            }

            ValidateSearchResult(html);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return ScrapeHTMLDoc(doc, targetURL);
        }

        public async Task<List<int>> ScrapeHTMLFileForRankingsAsync(string targetURL, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist.", filePath);

            string fileContent = await File.ReadAllTextAsync(filePath);

            if (string.IsNullOrWhiteSpace(fileContent) || !fileContent.TrimStart().StartsWith("<!DOCTYPE html", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("The file does not appear to be a valid HTML document.");

            var doc = new HtmlDocument();
            doc.LoadHtml(fileContent);

            return ScrapeHTMLDoc(doc, targetURL);
        }
    }
}
