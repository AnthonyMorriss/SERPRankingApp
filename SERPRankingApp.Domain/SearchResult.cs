using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Domain
{
    public class SearchResult
    {
        public int Id { get; set; }

        public string SearchTerm { get; set; } = string.Empty;
        public string TargetUrl { get; set; } = string.Empty;
        public List<int> RankResults { get; set; } = new List<int>();
        public DateTime SearchDate { get; set; }
    }
}
