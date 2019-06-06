namespace bondora.homeAssignment.Models.DTO.CartItem
{
    public class UpdateCartItemContract
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
    }
}
