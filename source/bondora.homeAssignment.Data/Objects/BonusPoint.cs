namespace bondora.homeAssignment.Data
{
    public class LoyaltyProgram : IId, INamed, IDeleteable
    {
        public long Id { get; set; }

        public bool Deleted { get; set; }

        public string Name { get; set; }

        public string Formula { get; set; }
    }
}
