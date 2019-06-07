using System.Threading.Tasks;
using bondora.homeAssignment.ApiClient.Api;
using bondora.homeAssignment.Core.Services.Contracts;
using bondora.homeAssignment.Models.Contracts.Common;
using bondora.homeAssignment.Models.Contracts.Invoice;

namespace bondora.homeAssignment.Web.Services
{
    public class RemoteInvoiceService : IInvoiceService
    {
        private readonly IInvoiceApi apiClient;

        public RemoteInvoiceService(IInvoiceApi apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<InvoiceContract> GetInvoice() => await this.apiClient.ApiInvoiceGetInvoiceGetAsync();
        public async Task<DocumentContract> GetPrintedInvoice() => await this.apiClient.ApiInvoiceGetPrintedInvoiceGetAsync();
    }
}
