namespace SERPRankingApp.UI.Models
{
    public class SearchResultResponse
    {
        public int Id { get; set; }

        public string SearchTerm { get; set; } = string.Empty;
        public string TargetUrl { get; set; } = string.Empty;
        public List<int> RankResults { get; set; } = new List<int>();
        public DateTime SearchDate { get; set; }
    }
}
