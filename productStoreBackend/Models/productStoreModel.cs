using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace productStoreBackend.Models
{
    [Keyless]
    public class productStoreModel
    {
        
        public int idStore { get; set; }

        public string codProduct { get; set; } = string.Empty;

        public int stock { get; set; }

    }
}
