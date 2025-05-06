using AutoMapper;
using SERPRankingApp.Application.Features.SearchResult;
using SERPRankingApp.Application.Features.SearchResult.Commands;
using SERPRankingApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Application.MappingProfiles
{
    public class SearchResultProfile : Profile
    {
        public SearchResultProfile()
        {
            CreateMap<SearchResult, SearchResultDto>().ReverseMap();
        }
    }
}
