namespace CatstagramDemoApp.Server.Infrastructure {
    public static class ConfigurationExtensions {
        //public static string GetDefaultConnection(this IConfiguration configuration) {
        //}
        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration) {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettingsSection");
            services.
                Configure<AppSettings>(applicationSettingsConfiguration);
            var appSettings = applicationSettingsConfiguration.Get<AppSettings>();

            return appSettings;
        }
    }
}
