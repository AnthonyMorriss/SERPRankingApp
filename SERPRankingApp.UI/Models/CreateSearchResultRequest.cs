namespace SERPRankingApp.UI.Models
{
    public class CreateSearchResultRequest
    {
        public string SearchTerm { get; set; } = string.Empty;
        public string TargetURL { get; set; } = string.Empty;
        public bool UseHTMLFile { get; set; } = false;
        public string HTMLFilePath { get; set; } = string.Empty;
    }
}
