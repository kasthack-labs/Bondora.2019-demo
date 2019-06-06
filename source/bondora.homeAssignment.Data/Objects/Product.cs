namespace bondora.homeAssignment.Data
{

    public class Product : IId, INamed, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
