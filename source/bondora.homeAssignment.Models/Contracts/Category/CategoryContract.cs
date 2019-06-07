namespace bondora.homeAssignment.Models.Contracts.Category
{
    public class CategoryContract
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string PricingFormula { get; set; }
        public string LoyaltyFormula { get; set; }
    }
}
