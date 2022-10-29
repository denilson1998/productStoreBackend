using System.ComponentModel.DataAnnotations;

namespace productStoreBackend.Models.responseModel
{
    public class cardModel
    {
        [Key]
        public int id { get; set; }
        public decimal total { get; set; }
        public decimal totalIva { get; set; }
        public int userId { get; set; }
    }
}
