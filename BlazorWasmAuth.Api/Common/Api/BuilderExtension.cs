using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorWasmAuth.Api.Data;
using BlazorWasmAuth.Api.Models;
using BlazorWasmAuth.Core;

namespace BlazorWasmAuth.Api.Common.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder
            .Configuration
            .GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        ApiConfiguration.StripeApiKey = builder.Configuration.GetValue<string>("StripeApiKey") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);
        });
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();
        builder.Services.AddAuthorization();
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x => {
            x.UseOracle(Configuration.ConnectionString, c => c.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19));
        });

        builder.Services.AddIdentityCore<User>()
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
                o => o.AddPolicy(
                    ApiConfiguration.CorsPolicyName,
                    p => p.WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                        ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    )
            );
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        //builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
        //builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
        //builder.Services.AddTransient<IReportHandler, ReportHandler>();
        //builder.Services.AddTransient<IOrderHandler, OrderHandler>();
        //builder.Services.AddTransient<IStripeHandler, StripeHandler>();
    }
}