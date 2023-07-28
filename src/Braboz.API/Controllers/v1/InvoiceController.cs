using Braboz.API.Controllers.Base;
using Braboz.Application.Models.User;
using Braboz.Application.Products.CQS.Commands.Invoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Braboz.API.Controllers.v1
{
    public class InvoiceController : ApiController
    {
        public InvoiceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceRequest command) =>
            await ExecuteCommandAsync<CreateInvoiceCommand, CreateInvoiceResponse>(new CreateInvoiceCommand(command.Id));
    }
}
