namespace VokaTester.Infrastructure.Profiles
{
    using AutoMapper;
    using VokaTester.Data.Models;
    using VokaTester.Features.Fortschritt.Dto;
    using VokaTester.Features.Lektionen.Dto;
    using VokaTester.Features.Vokabeln.Dto;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fortschritt, FortschrittDto>();
            CreateMap<Lektion, LektionDto>();
            CreateMap<Vokabel, VokabelDto>();
        }
    }
}
