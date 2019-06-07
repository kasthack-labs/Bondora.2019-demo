using bondora.homeAssignment.Models.Contracts.Category;

namespace bondora.homeAssignment.Models.Contracts.Product
{
    public class ProductContract
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public CategoryContract Category { get; set; }
    }
}
