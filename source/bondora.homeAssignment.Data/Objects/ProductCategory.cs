namespace bondora.homeAssignment.Data
{
    public class Category : IId, INamed, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }

        public string PricingFormula { get; set; }

        public virtual CategoryLoyaltyProgram BonusPoints { get; set; }
    }
}
