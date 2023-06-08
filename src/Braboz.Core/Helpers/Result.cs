namespace Braboz.Core.Helpers
{
    public class Result<T> : CustomResult
    {
        public Result(T data)
        {
            this.Data = data;
        }

        public T Data { get; }
    }
}
