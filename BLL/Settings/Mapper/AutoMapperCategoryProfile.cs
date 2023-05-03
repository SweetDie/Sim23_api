using AutoMapper;
using BLL.ViewModels.Category;
using DAL.Entities;

namespace BLL.Settings.Mapper
{
    public class AutoMapperCategoryProfile : Profile
    {
        public AutoMapperCategoryProfile()
        {
            // CategoryEntity -> CategoryVM
            CreateMap<CategoryEntity, CategoryVM>()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(dest => $"/images/{dest.Image}"));

            // CategoryCreateVM -> CategoryEntity
            CreateMap<CategoryCreateVM, CategoryEntity>()
                .ForMember(dest => dest.Image,
                    opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated,
                    opt => opt.MapFrom(dest => DateTime.Now.ToUniversalTime()))
                .ForMember(dest => dest.DateModified,
                    opt => opt.MapFrom(dest => DateTime.Now.ToUniversalTime()));

            // CategoryUpdateVM -> CategoryEntity
            CreateMap<CategoryUpdateVM, CategoryEntity>()
                .ForMember(dest => dest.Image,
                opt => opt.MapFrom(src => src.ImageBase64));
        }
    }
}
