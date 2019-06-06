using System.ComponentModel;

namespace bondora.homeAssignment.Models.DTO
{

    public class CartItemContract
    {
        public long Id { get; set; }

        [DisplayName("Duration")]
        public int Amount { get; set; }
        public ProductContract Product { get; set; }
    }
}
