using Microsoft.EntityFrameworkCore;
using SERPRankingApp.Domain;
using SERPRankingApp.Persistance.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Persistance.Repositories
{
    public class SERPRankingRepository : ISERPRankingRepository
    {
        private readonly SERPRankingDBContext _context;

        public SERPRankingRepository(SERPRankingDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(SearchResult seoSearch)
        {
            await _context.AddAsync(seoSearch);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SearchResult>> GetAllAsync()
        {
            return await _context.Set<SearchResult>().AsNoTracking().ToListAsync();
        }
    }
}
