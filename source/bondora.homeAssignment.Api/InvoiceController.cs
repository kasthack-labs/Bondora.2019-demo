using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Invoice;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Api
{
    [Route("api/[controller]/[action]")]

    public class InvoiceController : Controller
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoceService) {
            this.invoiceService = invoceService;
        }

        [HttpGet]
        public Task<InvoiceContract> GetInvoice() => this.invoiceService.GetInvoice();

        [HttpGet]
        public async Task<ActionResult> GetPrintedInvoice()
        {
            var invoice = await this.invoiceService.GetPrintedInvoice();
            return this.File(invoice.Content, invoice.Mime, invoice.Name);
        }
    }
}
