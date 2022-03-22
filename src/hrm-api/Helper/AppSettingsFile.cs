using hrm_core.Helper;
using System.Text.Json.Serialization;

namespace hrm_api.Helper
{
    public class AppSettingsFile
    {
        public AppSettings AzureAdB2C { get; set; }

        public static AppSettings ReadFromJsonFile()
        {
            IConfigurationRoot Configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json");

            Configuration = builder.Build();
            return Configuration.Get<AppSettingsFile>().AzureAdB2C;
        }
    }


}
