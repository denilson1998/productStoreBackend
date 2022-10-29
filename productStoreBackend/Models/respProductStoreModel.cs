using System.ComponentModel.DataAnnotations;

namespace productStoreBackend.Models
{
    public class respProductStoreModel
    {
        [Key]
        public string cod { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;
        public int idStore { get; set; }
        public string nameStore { get; set; }
        public Double price { get; set; }
        public int stock { get; set; }
    }
}
