using AutoMapper;
using PropertyImporter.Common.Models;

namespace PropertyImporter.Common.AutoMapperProfile
{
    public class DataMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Data.Models.Property, Property>()
                .ForMember(dest => dest.Name, src => src.MapFrom(p => p.Name))
                .ForMember(dest => dest.Address, src => src.MapFrom(p => p.Address))
                .ForMember(dest => dest.AgencyCode, src => src.MapFrom(p => p.AgencyCode))
                .ForMember(dest => dest.Latitude, src => src.MapFrom(p => p.Latitude))
                .ForMember(dest => dest.Longitude, src => src.MapFrom(p => p.Longitude))
                ;

            CreateMap<Property, Data.Models.Property>()
                .ForMember(dest => dest.PropertyId, src => src.Ignore())
                .ForMember(dest => dest.Name, src => src.MapFrom(p => p.Name))
                .ForMember(dest => dest.Address, src => src.MapFrom(p => p.Address))
                .ForMember(dest => dest.AgencyCode, src => src.MapFrom(p => p.AgencyCode))
                .ForMember(dest => dest.Latitude, src => src.MapFrom(p => p.Latitude))
                .ForMember(dest => dest.Longitude, src => src.MapFrom(p => p.Longitude))
                ;

            Mapper.AssertConfigurationIsValid();
        }
    }
}
