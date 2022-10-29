using System.ComponentModel.DataAnnotations;

namespace productStoreBackend.Models
{
    public class productModel
    {
        [Key]
        public string cod { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;

        public Double price { get; set; }
    }
}
