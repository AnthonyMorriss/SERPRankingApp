using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Application.Features.SearchResult.Queries
{
    public record GetSearchResultsQuery : IRequest<List<SearchResultDto>>;
}
