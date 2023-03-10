using MedicalstoreManagement.ExceptionHandlerMiddleware;
using MedicalstoreManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System;
using MedicalstoreManagement.Logger;

namespace MedicalstoreManagement.ExceptionHandlerMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;
        public ExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleException(httpContext, ex);
            }
        }
        private async Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorInfo()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
}
