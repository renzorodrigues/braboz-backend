using Braboz.Application.Models.User;
using Braboz.Application.Products.CQS.Queries;
using Braboz.Core.Helpers;
using MediatR;

namespace Braboz.Application.Products.Handlers.User
{
    public class UserHandler :
        IRequestHandler<GetAllUsersQuery, Result<IEnumerable<GetAllUsersResponse>>>
    {
        public UserHandler()
        {
        }

        public Task<Result<IEnumerable<GetAllUsersResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = new List<GetAllUsersResponse>();
            users.Add(new GetAllUsersResponse() { Names = "Renzo" });
            users.Add(new GetAllUsersResponse() { Names = "Julianna" });

            var result = new Result<IEnumerable<GetAllUsersResponse>>(users);

            return Task.FromResult(result);
        }
    }
}
