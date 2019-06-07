using bondora.homeAssignment.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Web.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService invoiceService;

        public InvoicesController(IInvoiceService invoiceService) => this.invoiceService = invoiceService;

        public async Task<ActionResult> Index()
        {
            var invoice = await this.invoiceService.GetPrintedInvoice().ConfigureAwait(false);
            return this.File(invoice.Content, invoice.Mime, invoice.Name);
        }
    }
}
