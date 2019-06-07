using System.Collections.Generic;

namespace bondora.homeAssignment.Data
{
    public class Category : IId, INamed, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string PricingFormula { get; set; }

        public virtual CategoryLoyaltyProgram CategoryLoyaltyProgram { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
