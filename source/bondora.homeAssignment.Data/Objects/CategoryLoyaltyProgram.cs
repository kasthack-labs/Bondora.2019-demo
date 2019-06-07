namespace bondora.homeAssignment.Data
{

    public class CategoryLoyaltyProgram : IId, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public long CategoryId { get; set; }
        public long LoyaltyProgramId { get; set; }

        public virtual Category Category { get; set; }
        public virtual LoyaltyProgram LoyaltyProgram { get; set; }
    }
}
