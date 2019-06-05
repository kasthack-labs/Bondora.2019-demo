namespace bondora.homeAssignment.Data
{

    public class Price : IId, INamed, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
