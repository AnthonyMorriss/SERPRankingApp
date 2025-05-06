using SERPRankingApp.Domain;

namespace SERPRankingApp.Persistance.Repositories
{
    public interface ISERPRankingRepository
    {
        Task CreateAsync(SearchResult seoSearch);
        Task<List<SearchResult>> GetAllAsync();
    }
}