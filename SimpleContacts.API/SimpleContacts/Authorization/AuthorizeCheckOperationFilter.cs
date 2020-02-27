using System.Linq;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SimpleContacts.Web.Authorization
{
    internal class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check for authorize attribute
            var isNotAuthorized = context.MethodInfo.DeclaringType != null && context.MethodInfo.DeclaringType
                                   .GetCustomAttributes(true)
                                   .Union(context.MethodInfo.GetCustomAttributes(true))
                                   .OfType<AuthorizeAttribute>()
                                   .Any();

            if (isNotAuthorized)
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

                var oAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [oAuthScheme] = new [] { IdentityServerConfig.ApiName}
                    }
                };
            }
        }
    }
}
