using System.ComponentModel.DataAnnotations;

namespace productStoreBackend.Models
{
    public class addProductCardModel
    {
        [Key]
        public string cod { get; set; } = string.Empty;

        public int idStore { get; set; }

        public int userId { get; set; }
        public Double amount { get;set; }

    }
}
