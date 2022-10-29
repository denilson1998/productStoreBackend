using System.ComponentModel.DataAnnotations;

namespace productStoreBackend.Models
{
    public class updateProductModel
    {
        [Key]
        public string cod { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;
        public Double price { get; set; }
        public int stock { get; set; }
        public int idStore { get; set; }
    }
}
