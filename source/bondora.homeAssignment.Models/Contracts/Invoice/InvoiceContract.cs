using bondora.homeAssignment.Models.Contracts.Cart;
using System.Collections.Generic;
using System.Linq;

namespace bondora.homeAssignment.Models.Contracts.Invoice
{
    public class InvoiceContract
    {
        public string Title { get; set; }
        public IEnumerable<CartItemContract> Items { get; set; }
        public decimal Price => this.Items.Any() ? this.Items.Sum(a => a.Price) : 0;
        public int LoyaltyPoints => this.Items.Any() ? this.Items.Sum(a => a.LoyaltyPoints) : 0;
    }
}
