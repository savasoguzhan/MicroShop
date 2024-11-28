using AutoMapper;
using MicroShop.Catalog.Dtos.CategoryDtos;
using MicroShop.Catalog.Dtos.FeatureSliderDtos;
using MicroShop.Catalog.Dtos.ProductDetailsDtos;
using MicroShop.Catalog.Dtos.ProductDtos;
using MicroShop.Catalog.Dtos.ProductImagesDtos;
using MicroShop.Catalog.Entities;

namespace MicroShop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();

            CreateMap<ProductImages, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImages, UpdateProducyImageDto>().ReverseMap();
            CreateMap<ProductImages, CreateProductImageDto>().ReverseMap();


            CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();

        }
    }
}
