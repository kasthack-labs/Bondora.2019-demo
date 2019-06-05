namespace bondora.homeAssignment.Data
{
    public class ProductCategory : IId, INamed, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }

        public string PricingFormula { get; set; }

        public virtual CategoryBonusPoint BonusPoints { get; set; }
    }
}
