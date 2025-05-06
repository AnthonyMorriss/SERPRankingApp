using MediatR;
using Microsoft.AspNetCore.Mvc;
using SERPRankingApp.Application.Features.SearchResult;
using SERPRankingApp.Application.Features.SearchResult.Commands;
using SERPRankingApp.Application.Features.SearchResult.Queries;

namespace SERPRankingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchResultController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SearchResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateSearchResult")]
        public async Task<ActionResult> CreateSearchResult([FromBody] CreateSearchResultCommand command)
        {
            SearchResultDto result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetSearchResults")]
        public async Task<ActionResult<List<SearchResultDto>>> GetSearchResults()
        {
            List<SearchResultDto> results = await _mediator.Send(new GetSearchResultsQuery());

            return Ok(results);
        }
    }
}
