namespace MMS.DataManager
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<DataManagerHttpApiHostModule>();
        }

        public void Configure(IApplicationBuilder app,IHostApplicationLifetime lifetime)
        {
            app.InitializeApplication();
        }
    }
}
