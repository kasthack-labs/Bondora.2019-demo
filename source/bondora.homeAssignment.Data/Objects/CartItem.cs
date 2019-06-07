namespace bondora.homeAssignment.Data
{
    public class CartItem : IId, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public int Duration { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
