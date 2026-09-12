using Microsoft.AspNetCore.Http;
using MyFirstAPI.Exceptions;

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
            try
            {
                await next(context);
            }

            catch (ClienteNaoEncontradoException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync (ex.Message);
            }

            catch (FuncionarioNaoEncontradoException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync (ex.Message);
            }
        }
        
    }
}