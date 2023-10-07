using Application.Features.Models.Queries.GeList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model,GetListModelListItemDto>().
            ForMember(destinationMember:m =>m.BrandName, memberOptions:opt => opt.MapFrom(c => c.Brand.Name)).
            ForMember(destinationMember:m =>m.FuelName, memberOptions:opt => opt.MapFrom(c => c.Fuel.Name)).
            ForMember(destinationMember:m =>m.TransmissionName, memberOptions:opt => opt.MapFrom(c => c.Transmission.Name)).
            ReverseMap();
        CreateMap<Paginate<Model>,GetListResponse<GetListModelListItemDto>>().ReverseMap();
    }
}
