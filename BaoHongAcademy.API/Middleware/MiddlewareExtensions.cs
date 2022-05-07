using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoHongAcademy.API.Middleware
{
    public static class MiddlewareExtensions
    {
        public static void UseHandleErrorMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<HandleErrorMiddleware>();
        }
    }
}
