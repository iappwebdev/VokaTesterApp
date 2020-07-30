namespace VokaTester.Infrastructure.Profiles
{
    using AutoMapper;
    using VokaTester.Data.Models;
    using VokaTester.Features.Vokabeln.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lektion, LektionListingServiceModel>();
            CreateMap<Vokabel, VokabelListingServiceModel>();
        }
    }
}
