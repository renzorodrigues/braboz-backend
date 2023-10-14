using Braboz.Application.Models.User;
using Braboz.Application.Products.CQS.Queries;
using Braboz.Core.Helpers;
using Braboz.Core.Interfaces;
using Braboz.Core.Settings;
using MediatR;

namespace Braboz.Application.Products.Handlers.User
{
    public class UserHandler :
        IRequestHandler<GetAllUsersQuery, Result<IEnumerable<GetAllUsersResponse>>>
    {
        private readonly IHttpClient httpClient;

        public UserHandler(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<GetAllUsersResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await this.httpClient.CreateClient<GetAllUsersResponse>(HttpClientEnum.Users);

            return new Result<IEnumerable<GetAllUsersResponse>>(result);
        }
    }
}
