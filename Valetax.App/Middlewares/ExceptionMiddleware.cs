using System.Net;
using System.Text.Json;
using Valetax.Domain.Models.Exceptions;
using Valetax.Services.Interfaces;
using Valetax.Services.Model.DTOs;

namespace Valetax.App.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    private readonly IExceptionJournalService _exceptionJournalService;

    public ExceptionMiddleware(IExceptionJournalService exceptionJournalService)
    {
        _exceptionJournalService = exceptionJournalService;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (SecureException ex)
        {
            await HandleExceptionAsync(context, ex, ex.GetType().Name);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, nameof(Exception));
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, string name)
    {
        var dto = await _exceptionJournalService.CreateNodeAsync(new ExceptionJournalDto()
        {
            StackTrace = exception.StackTrace,
            RequestParameters = context.Request.QueryString.Value,
            Type = name,
            TraceIdentifier = context.Request.HttpContext.TraceIdentifier,
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
        {
            Id = dto.TraceIdentifier,
            Type = name,
            Data = exception.Message
        }));
    }
}