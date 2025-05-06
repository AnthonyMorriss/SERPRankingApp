using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Application.Contracts
{
    public interface ISearchScraperService
    {
        Task<List<int>> ScrapeGoogleForRankingsAsync(string searchTerm, string targetURL);
        Task<List<int>> ScrapeHTMLFileForRankingsAsync(string targetURL, string filePath);
    }
}
