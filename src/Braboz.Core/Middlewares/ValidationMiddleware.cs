using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Braboz.Core.Middlewares
{
    public class ValidationMiddleware : IMiddleware
    {
        public string? MyProperty { get; set; }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            this.MyProperty = "Pronto!";
            Console.WriteLine(this.MyProperty);

            var request = context.Request;
            if (request.Method == HttpMethods.Post && request.ContentLength > 0)
            {
                request.EnableBuffering();
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                request.Body.ReadAsync(buffer, 0, buffer.Length);
                //get body string here...
                var requestContent = Encoding.UTF8.GetString(buffer);

                request.Body.Position = 0;  //rewinding the stream to 0
            }

            return next(context);
        }
    }
}
