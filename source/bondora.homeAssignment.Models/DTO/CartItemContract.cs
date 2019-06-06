namespace bondora.homeAssignment.Models.DTO
{

    public class CartItemContract
    {
        public long Id { get; set; }
        public int Amout { get; set; }
        public ProductContract Product { get; set; }
    }
}
