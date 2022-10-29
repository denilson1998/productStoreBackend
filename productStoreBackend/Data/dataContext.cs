using Microsoft.EntityFrameworkCore;
using productStoreBackend.Models;
using productStoreBackend.Models.responseModel;

namespace productStoreBackend.Data
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<storeModel> stores { get; set; }
        public DbSet<productModel> products { get; set;  }

        public DbSet<productStoreModel> productStore { get; set; }

        public DbSet<cardModel> storeCard { get; set; }
    }
}
