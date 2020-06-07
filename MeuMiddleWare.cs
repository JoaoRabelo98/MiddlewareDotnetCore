using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public class MeuMiddleWare
{
  private readonly RequestDelegate _next;

  public MeuMiddleWare(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    Console.WriteLine("\n\r -----Before----- \n\r");

    await _next(context);

    Console.WriteLine("\n\r -----After----- \n\r");
  }
}

public static class MeuMiddleWareExtension
{
  public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<MeuMiddleWare>();
  }
}