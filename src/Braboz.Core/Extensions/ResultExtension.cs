using System.Net;
using Braboz.Core.Constants;
using Braboz.Core.Helpers;

namespace Braboz.Core.Extensions
{
    public static class ResultExtension
    {
        public static Result<IEnumerable<T>> BadRequest<T>(this IEnumerable<T> result, string? message = null)
        {
            if (result.Any())
                return new Result<IEnumerable<T>>(result);

            return new Result<IEnumerable<T>>(result) { Message = ConstantStrings.EMPTY_LIST };
        }
    }
}
