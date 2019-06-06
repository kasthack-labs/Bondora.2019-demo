namespace bondora.homeAssignment.Data
{
    public class CartItem : IId, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public int Amount { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
