using Braboz.Core.Settings;

namespace Braboz.Core.Interfaces
{
    public interface IHttpClient
    {
        Task<IEnumerable<T>> CreateClient<T>(HttpClientEnum httpClientEnum);
    }
}
