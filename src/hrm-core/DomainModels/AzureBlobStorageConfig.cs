namespace hrm_core.DomainModels
{
    public class AzureBlobStorageConfig
    {
        public string ConnectionString { get; set; }
        public string Container { get; set; }
        public string AccountName { get; set; }
        public string SasToken { get; set; }
    }
}
