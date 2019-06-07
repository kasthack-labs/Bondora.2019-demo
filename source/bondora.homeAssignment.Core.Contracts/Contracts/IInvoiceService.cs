using bondora.homeAssignment.Models.Contracts.Common;
using bondora.homeAssignment.Models.Contracts.Invoice;
using System.Threading.Tasks;

namespace bondora.homeAssignment.Core.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<InvoiceContract> GetInvoice();
        Task<DocumentContract> GetPrintedInvoice();
    }
}