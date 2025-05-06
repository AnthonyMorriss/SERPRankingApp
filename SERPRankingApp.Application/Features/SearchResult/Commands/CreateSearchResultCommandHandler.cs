using AutoMapper;
using MediatR;
using SERPRankingApp.Application.Contracts;
using SERPRankingApp.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Application.Features.SearchResult.Commands
{
    public class CreateSearchResultCommandHandler : IRequestHandler<CreateSearchResultCommand, SearchResultDto>
    {
        private readonly ISERPRankingRepository _repository;
        private readonly IMapper _mapper;
        private readonly ISearchScraperService _searchScraper;

        public CreateSearchResultCommandHandler(ISERPRankingRepository searchResultRepository, IMapper mapper, ISearchScraperService searchScraper)
        {
            _repository = searchResultRepository;
            _mapper = mapper;
            _searchScraper = searchScraper;
        }

        public async Task<SearchResultDto> Handle(CreateSearchResultCommand request, CancellationToken cancellationToken)
        {
            // Validate the request

            List<int> results = new List<int>();

            if (request.UseHTMLFile)
            {
                results = await _searchScraper.ScrapeHTMLFileForRankingsAsync(request.TargetURL, request.HTMLFilePath);
            }
            else
            {
                results = await _searchScraper.ScrapeGoogleForRankingsAsync(request.SearchTerm, request.TargetURL);
            }

            var searchResultToCreate = new Domain.SearchResult
            {
                SearchTerm = request.SearchTerm,
                TargetUrl = request.TargetURL,
                RankResults = results,
                SearchDate = DateTime.UtcNow
            };

            await _repository.CreateAsync(searchResultToCreate);

            var searchResult = _mapper.Map<SearchResultDto>(searchResultToCreate);

            return searchResult;
        }
    }
}
