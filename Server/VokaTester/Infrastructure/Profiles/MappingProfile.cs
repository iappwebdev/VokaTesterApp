namespace VokaTester.Infrastructure.Profiles
{
    using AutoMapper;
    using VokaTester.Data.Models;
    using VokaTester.Features.Fortschritt.Dto;
    using VokaTester.Features.Lektionen.Dto;
    using VokaTester.Features.TestResults.Dto;
    using VokaTester.Features.Vokabeln.Dto;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bereich, BereichDto>();
            CreateMap<Fortschritt, FortschrittDto>();
            CreateMap<Lektion, LektionDto>();
            CreateMap<TestResult, TestResultDto>();
            CreateMap<Vokabel, VokabelDto>();
        }
    }
}
