using AutoMapper;
using bondora.homeAssignment.Data;
using bondora.homeAssignment.Models.Contracts.Cart;
using bondora.homeAssignment.Models.Contracts.Category;
using bondora.homeAssignment.Models.Contracts.Product;

namespace bondora.homeAssignment.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CategoryContract>()
                .ForMember(a=>a.LoyaltyFormula, cfg => cfg.MapFrom(source => source.CategoryLoyaltyProgram.LoyaltyProgram.Formula))
                .ReverseMap();
            this.CreateMap<Product, ProductContract>().ReverseMap();
            this.CreateMap<CartItem, CartItemContract>().ReverseMap();

            this.CreateMap<CreateCartItemContract, CartItem>();
            this.CreateMap<UpdateCartItemContract, CartItem>();
        }
    }
}
