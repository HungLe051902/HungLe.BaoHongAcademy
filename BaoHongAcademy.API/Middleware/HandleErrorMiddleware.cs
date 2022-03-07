using BaoHongAcademy.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaoHongAcademy.API.Middleware
{
    public class HandleErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public HandleErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                // Switch case các loại Exception ở đây, dựa vào InnerException

                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status500InternalServerError;

                var result = JsonSerializer.Serialize(new ActionServiceResult() { 
                    Success = false,
                    AppCode = StatusCodes.Status500InternalServerError,
                    Message = error?.Message,
                    Data = null
                });
                await response.WriteAsync(result);
            }
        }
    }
}
