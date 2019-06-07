using bondora.homeAssignment.Models.Contracts.Product;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bondora.homeAssignment.Models.Contracts.Cart
{
    public class CartItemContract
    {
        //move to config
        internal const int MinDuration = 1;
        internal const int MaxDuration = 30;
        //todo: localizeable
        internal const string DurationMessage = "Currently we only allow rent from 1 to 30 days. If you are interested in long-term rent, contact our sales";

        public long Id { get; set; }

        [Range(CartItemContract.MinDuration, CartItemContract.MaxDuration, ErrorMessage = CartItemContract.DurationMessage)]
        public int Duration { get; set; }
        public ProductContract Product { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Loyalty points")]
        public int LoyaltyPoints { get; set; }
    }
}
