using System.ComponentModel.DataAnnotations;

namespace bondora.homeAssignment.Models.Contracts.Cart
{
    public class CreateCartItemContract
    {
        public long ProductId { get; set; }
        [Range(CartItemContract.MinDuration, CartItemContract.MaxDuration, ErrorMessage = CartItemContract.DurationMessage)]
        public int Duration { get; set; }
    }
}
