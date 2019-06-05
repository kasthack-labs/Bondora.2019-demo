namespace bondora.homeAssignment.Data
{
    public class CartItem : IId, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
    }
}
