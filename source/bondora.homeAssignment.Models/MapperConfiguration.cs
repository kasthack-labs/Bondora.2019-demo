using AutoMapper;
using bondora.homeAssignment.Data;
using bondora.homeAssignment.Models.DTO;
using bondora.homeAssignment.Models.DTO.CartItem;

namespace bondora.homeAssignment.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CategoryContract>().ReverseMap();
            this.CreateMap<Product, ProductContract>().ReverseMap();
            this.CreateMap<CartItem, CartItemContract>().ReverseMap();
            this.CreateMap<CreateCartItemContract, CartItem>();
            this.CreateMap<UpdateCartItemContract, CartItem>();
        }
    }
}
