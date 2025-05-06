using AutoMapper;
using MediatR;
using SERPRankingApp.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Application.Features.SearchResult.Queries
{
    public class GetSearchResultsQueryHandler : IRequestHandler<GetSearchResultsQuery, List<SearchResultDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISERPRankingRepository _repository;

        public GetSearchResultsQueryHandler(IMapper mapper, ISERPRankingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<SearchResultDto>> Handle(GetSearchResultsQuery request, CancellationToken cancellationToken)
        {
            List<Domain.SearchResult> searchResults = await _repository.GetAllAsync();

            List<SearchResultDto> searchResultsDto = _mapper.Map<List<SearchResultDto>>(searchResults);

            return searchResultsDto;
        }
    }
}
