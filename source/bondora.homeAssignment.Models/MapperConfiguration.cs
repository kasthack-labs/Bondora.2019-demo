using AutoMapper;
using bondora.homeAssignment.Data;
using bondora.homeAssignment.Models.DTO;

namespace bondora.homeAssignment.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CategoryContract>().ReverseMap();
            this.CreateMap<Product, ProductContract>().ReverseMap();
            this.CreateMap<CartItem, CartItemContract>().ReverseMap();
        }
    }
}
