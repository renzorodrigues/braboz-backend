using Braboz.Application.Models.User;
using Braboz.Application.Products.CQS.Commands.Invoice;
using Braboz.Application.Services.Interfaces.Invoice;
using Braboz.Core.Helpers;
using Braboz.Core.Settings;
using MediatR;
using Microsoft.Extensions.Options;

namespace Braboz.Application.Products.Handlers.Invoice
{
    public class InvoiceHandler :
        IRequestHandler<CreateInvoiceCommand, Result<CreateInvoiceResponse>>
    {
        private readonly IInvoiceService invoiceService;
        private readonly HttpClientSettings httpClientSettings;

        public InvoiceHandler(
            IInvoiceService invoiceService,
            IOptions<HttpClientSettings> options)
        {
            this.invoiceService = invoiceService;
            this.httpClientSettings = options.Value;
        }

        public Task<Result<CreateInvoiceResponse>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = this.invoiceService.CreateInvoice(this.httpClientSettings);

            return Task.FromResult(new Result<CreateInvoiceResponse>(invoice.Result));
        }
    }
}
