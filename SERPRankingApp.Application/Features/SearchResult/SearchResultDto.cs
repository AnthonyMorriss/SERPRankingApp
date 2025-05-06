using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Application.Features.SearchResult
{
    public class SearchResultDto
    {
        public int Id { get; set; }

        public string SearchTerm { get; set; } = string.Empty;
        public string TargetUrl { get; set; } = string.Empty;
        public List<int> RankResults { get; set; } = new List<int>();
        public DateTime SearchDate { get; set; }
    }
}
