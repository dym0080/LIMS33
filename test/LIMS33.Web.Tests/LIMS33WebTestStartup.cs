using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace LIMS33
{
    public class LIMS33WebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<LIMS33WebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}