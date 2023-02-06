using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace WebAPI.Application.Filters
{
    public class ApiKeyAuthentication: Attribute, IAsyncActionFilter
    {
        private const string apiKeyHeaderName = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue(apiKeyHeaderName, out var potentialKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var myApiKey = context.HttpContext.RequestServices
                                                .GetRequiredService<IConfiguration>()
                                                .GetValue<string>("ApiKey");
            if(myApiKey != potentialKey)
            {
                context.Result = new UnauthorizedResult();
                return;              
            }
            
            await next();
        }
    }
}