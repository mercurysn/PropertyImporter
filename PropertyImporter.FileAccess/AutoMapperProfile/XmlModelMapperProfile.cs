using AutoMapper;
using PropertyImporter.Common.Models;
using PropertyImporter.FileAccess.XmlModel;

namespace PropertyImporter.FileAccess.AutoMapperProfile
{
    public class XmlModelMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<PropertyDeserializer, Property>()
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
