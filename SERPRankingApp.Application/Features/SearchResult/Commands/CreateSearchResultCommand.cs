using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Application.Features.SearchResult.Commands
{
    public class CreateSearchResultCommand : IRequest<SearchResultDto>
    {
        public string SearchTerm { get; set; } = string.Empty;
        public string TargetURL { get; set; } = string.Empty;
        public bool UseHTMLFile { get; set; } = false;
        public string HTMLFilePath { get; set; } = string.Empty;
    }
}
