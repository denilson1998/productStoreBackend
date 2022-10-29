namespace productStoreBackend.Models.responseModel
{
    public class responseModel
    {
        public int state { get; set; }
        public string message { get; set; } = string.Empty;
        public object detail { get; set; } = string.Empty;
    }
}
