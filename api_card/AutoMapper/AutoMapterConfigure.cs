using api_card.DTO;
using api_card.DTO_output;
using api_card.Model;
using AutoMapper;

namespace api_card.AutoMapper
{
    public class AutoMapterConfigure : Profile
    {
        public AutoMapterConfigure()
        {
            CreateMap<Card_DTO, Cart>();
            CreateMap<ProductCart, Product_CardDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                ;
        }
    }
}
