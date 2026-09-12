using Microsoft.AspNetCore.Http;

namespace MyFirstAPI.Migrations
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await next(context);
        }
    }
}