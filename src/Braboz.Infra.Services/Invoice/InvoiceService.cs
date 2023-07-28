using Braboz.Application.Models.User;
using Braboz.Application.Services.Interfaces.HttpClient;
using Braboz.Application.Services.Interfaces.Invoice;
using Braboz.Core.Settings;

namespace Braboz.Infra.Services.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IHttpClient httpClient;

        public InvoiceService(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CreateInvoiceResponse> CreateInvoice(HttpClientSettings httpClientSettings)
        {
            throw new NotImplementedException();

            //var result = await this.httpClient
            //    .CreateClient<CreateInvoiceResponse>(
            //        httpClientSettings.BaseAddress!,
            //        httpClientSettings.RequestUri!);

            //return result.First();
        }
    }
}
