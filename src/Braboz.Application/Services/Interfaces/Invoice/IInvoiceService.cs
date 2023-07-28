using Braboz.Application.Models.User;
using Braboz.Core.Settings;

namespace Braboz.Application.Services.Interfaces.Invoice
{
    public interface IInvoiceService
    {
        Task<CreateInvoiceResponse> CreateInvoice(HttpClientSettings clientSettings);
    }
}
