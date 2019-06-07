using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Common;
using bondora.homeAssignment.Models.Contracts.Invoice;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Impl
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ICartService cartService;
        private readonly ILogger<InvoiceService> logger;

        public InvoiceService(ICartService cartService, ILogger<InvoiceService> logger)
        {
            this.cartService = cartService;
            this.logger = logger;
        }

        public async Task<InvoiceContract> GetInvoice()
        {
            var invoice = new InvoiceContract
            {
                Title = $"Equipment rental invoice {DateTimeOffset.Now:yyyy-MM-dd hh:MMZ}",
                Items = await this.cartService.List().ConfigureAwait(false),
            };
            this.logger.LogDebug($"Generated invoice '{invoice.Title}' with {invoice.Items.Count()} items of equipment totaling for {invoice.Price} EUR");
            return invoice;
        }

        public async Task<DocumentContract> GetPrintedInvoice()
        {
            var model = await this.GetInvoice().ConfigureAwait(false);
            var currency = Currency.CurrencySymbol;
            var formattedItems = model.Items.Select(item => new {
                Name = item.Product.Name,
                Price = $"{currency}{item.Price:F2}",
                Duration = $"{item.Duration}",
                LoyaltyPoints = $"{item.LoyaltyPoints}",
            }).ToArray();

            var totalPrice = $"{currency}{model.Price:F2}";
            var totalLoyaltyPoints = $"{model.LoyaltyPoints}";

            const int columnSpacing = 3;

            const string nameColumn = "Name";
            var nameColumnWidth = Math.Max(nameColumn.Length, formattedItems.Max(a=>a.Name.Length)) + columnSpacing;

            const string durationColumn = "Duration(days)";
            var durationColumnWidth = Math.Max(durationColumn.Length, formattedItems.Max(a => a.Duration.Length)) + columnSpacing;

            const string priceColumn = "Price";
            var priceColumnWidth = Math.Max(totalPrice.Length, Math.Max(priceColumn.Length, formattedItems.Max(a => a.Price.Length))) + columnSpacing;

            const string loyaltyPointsColumn = "Loyalty Points";
            var loyaltyPointsColumnWidth = Math.Max(totalLoyaltyPoints.Length, Math.Max(loyaltyPointsColumn.Length, formattedItems.Max(a => a.LoyaltyPoints.Length)));

            var headerRow = $"{nameColumn.PadRight(nameColumnWidth, ' ')}{durationColumn.PadRight(durationColumnWidth)}{priceColumn.PadRight(priceColumnWidth)}{loyaltyPointsColumn.PadRight(loyaltyPointsColumnWidth)}";

            var tableWidth = headerRow.Length;
            var separatorRow = new string('-', tableWidth);

            const string totalColumn = "Total";
            var totalRow = $"{totalColumn}{($"{totalPrice.PadRight(priceColumnWidth)}{totalLoyaltyPoints.PadRight(loyaltyPointsColumnWidth)}").PadLeft(tableWidth-totalColumn.Length)}";

            var sb = new StringBuilder();
            sb.AppendLine($"# {model.Title}");
            sb.AppendLine();
            sb.AppendLine(headerRow);
            foreach (var item in formattedItems)
            {
                sb.AppendLine($"{item.Name.PadRight(nameColumnWidth)}{item.Duration.PadRight(durationColumnWidth)}{item.Price.PadRight(priceColumnWidth)}{item.LoyaltyPoints.PadRight(loyaltyPointsColumnWidth)}");
            }
            sb.AppendLine(separatorRow);
            sb.AppendLine(totalRow);
            var invoice = sb.ToString();
            return new DocumentContract
            {
                Content = Encoding.UTF8.GetBytes(invoice),
                Mime = "text/plain",
                Name = $"Equipment rental invoice {DateTimeOffset.Now:yyyy-MM-dd}.txt",
            };
        }
    }
}
