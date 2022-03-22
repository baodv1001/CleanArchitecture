using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace hrm_core.Helper
{
    public class AppSettings
    {
        [JsonPropertyName("TenantId")]
        public string TenantId { get; set; }

        [JsonPropertyName("ClientId")]
        public string ClientId { get; set; }

        [JsonPropertyName("ClientSecret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("B2cExtensionAppClientId")]
        public string B2cExtensionAppClientId { get; set; }

    }
}
