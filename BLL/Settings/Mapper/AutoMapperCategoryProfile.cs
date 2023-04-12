using AutoMapper;
using BLL.ViewModels.Category;
using DAL.Entities;

namespace BLL.Settings.Mapper
{
    public class AutoMapperCategoryProfile : Profile
    {
        public AutoMapperCategoryProfile()
        {
            // Category -> CategoryVM
            CreateMap<Category, CategoryVM>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name));
        }
    }
}
