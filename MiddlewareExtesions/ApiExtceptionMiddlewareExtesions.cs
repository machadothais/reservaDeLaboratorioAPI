using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ApiCatalogo.Extensions;

public static class ApiExtceptionMiddlewareExtesions
{
    public static void ConfigureApiExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature?.Error != null)
                    {
                        var errorDetails = new
                        {
                            Status = context.Response.StatusCode,
                            Message =contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        };
                        await context.Response.WriteAsJsonAsync(errorDetails);
                    }
                });
            }
            );
            
    }

}