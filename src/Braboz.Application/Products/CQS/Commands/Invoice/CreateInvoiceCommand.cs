using Braboz.Application.Models.User;
using Braboz.Core.Handlers;

namespace Braboz.Application.Products.CQS.Commands.Invoice
{
    public class CreateInvoiceCommand : Command<CreateInvoiceResponse>
    {
        public int Id { get; set; }

        public CreateInvoiceCommand(int id)
        {
            RequestId = Guid.NewGuid();
            this.Id = id;
        }
    }
}
