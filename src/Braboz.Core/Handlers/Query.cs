using System.Text.Json.Serialization;
using Braboz.Core.Handlers.Interfaces;

namespace Braboz.Core.Handlers
{
    public abstract class Query<TResult> : IQuery<TResult>
    {
        [JsonIgnore]
        public Guid RequestId { get; set; }
    }
}
