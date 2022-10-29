using System.ComponentModel.DataAnnotations;

namespace productStoreBackend.Models
{
    public class storeModel
    {

        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
    }
}
