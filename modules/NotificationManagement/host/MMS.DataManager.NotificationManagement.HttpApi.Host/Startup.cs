using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MMS.DataManager.NotificationManagement;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<NotificationManagementHttpApiHostModule>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}