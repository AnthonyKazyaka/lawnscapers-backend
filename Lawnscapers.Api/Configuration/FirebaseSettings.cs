using System.Text.Json.Serialization;

namespace Lawnscapers.Api.Configuration
{
    public class FirebaseSettings
    {
        public string? Type { get; set; }
        [JsonPropertyName("project_id")] public string? ProjectId { get; set; }
        [JsonPropertyName("private_key_id")] public string? PrivateKeyId { get; set; }
        [JsonPropertyName("private_key")] public string? PrivateKey { get; set; }
        public string? client_email { get; set; }
        public string? client_id { get; set; }
        public string? auth_uri { get; set; }
        public string? token_uri { get; set; }
        public string? auth_provider_x509_cert_url { get; set; }
        public string? client_x509_cert_url { get; set; }
        public string? universe_domain { get; set; }
    }

}
