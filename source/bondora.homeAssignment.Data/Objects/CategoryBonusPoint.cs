namespace bondora.homeAssignment.Data
{

    public class CategoryLoyaltyProgram : IId, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public long BonusPointsId { get; set; }
        public long ProductCategoryId { get; set; }

        public virtual LoyaltyProgram BonusPoint { get; set; }

        public virtual Category ProductCategory { get; set; }
    }
}
