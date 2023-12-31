﻿using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.CrossCuttingConcerns.Serilog;
using Core.Persistence.Models.Responses;

namespace Shop.UI.Api.Middleware;

public static class ExceptionHandlerMiddlewareExtension
{
    #region For Use

    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlerMiddleware>();
    }

    #endregion
}
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly LoggerServiceBase _loggerServiceBase;
    public ExceptionHandlerMiddleware(RequestDelegate next, LoggerServiceBase loggerServiceBase)
    {
        _next = next;
        _loggerServiceBase = loggerServiceBase;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException error)
        {
            var errors = string.Join("<br/>", error.Errors.SelectMany(w => w.Errors ?? new List<string>()));
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(errors, 400));
        }
        catch (BusinessException error)
        {
            _loggerServiceBase.Error(error.Message);
            if (!string.IsNullOrEmpty(error.StackTrace))
                _loggerServiceBase.Error(error.StackTrace);
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 400));

        }
        catch (NotFoundException error)
        {
            _loggerServiceBase.Error(error.Message);
            if (!string.IsNullOrEmpty(error.StackTrace))
                _loggerServiceBase.Error(error.StackTrace);
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 400));
        }
        catch (Exception error)
        {
            _loggerServiceBase.Error(error.Message);
            if (!string.IsNullOrEmpty(error.StackTrace))
                _loggerServiceBase.Error(error.StackTrace);
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail("İşlem sırasında bir hata oluştu.", 500));
        }

    }

}