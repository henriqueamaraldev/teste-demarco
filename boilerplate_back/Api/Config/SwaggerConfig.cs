using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Config
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfig(this IServiceCollection services,
           IConfiguration configuration)
        {

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Minha API",
                    Version = "v1",
                    Description = "Documentação interativa para minha API .NET 9"
                });

                // Adicionar suporte a autenticação (opcional)
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Insira o token JWT no formato: Bearer {seu_token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                options.OperationFilter<SwaggerFileOperationFilter>();
            });
        }
    }

    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParams = context.ApiDescription.ParameterDescriptions
                .Where(p => p.ModelMetadata?.ModelType == typeof(IFormFile));

            foreach (var param in fileParams)
            {
                var schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "binary"
                };

                operation.RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["multipart/form-data"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "object",
                                Properties = { { param.Name, schema } },
                                Required = new HashSet<string> { param.Name }
                            }
                        }
                    }
                };
            }
        }
    }
}


