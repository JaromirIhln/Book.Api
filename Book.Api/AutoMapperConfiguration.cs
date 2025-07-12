using AutoMapper;
using Book.Api.Models;
using Book.Data.Models;

namespace Book.Api
{
    /// <summary>
    /// Provides a configuration profile for AutoMapper to map between data models and DTOs.
    /// </summary>
    /// <remarks>This class defines mapping configurations using AutoMapper's <see cref="Profile"/> base
    /// class. It includes mappings between <see cref="Books"/> and <see cref="BookDto"/> with reverse
    /// mapping enabled. Additional mappings can be configured by uncommenting the provided examples or adding new ones
    /// as needed.</remarks>
    public class AutoMapperConfiguration: Profile
    {
        /// <summary>
        /// Mapping configuration for AutoMapper.
        /// </summary>
        public AutoMapperConfiguration()
        {
            CreateMap<Books, BookDto>().ReverseMap();

            // Uncomment the following lines if you want to create additional mappings examples
            // CreateMap<Books, BookDto>().ReverseMap();
            // CraeteMap<BookDto, Books>().ReverseMap();
            // CreateMap<BookDto, Books>();

            // Specify the mapping between Books and BookDto
            // CreateMap<Books, BookDto>()
            //     .ForMember(dest => dest.CraatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            //     .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.Available));
            // CreateMap<BookDto, Books>()
            //     .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CraatedAt))
            //     .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.IsAvailable));

        }
    }
}
