using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class AssetsDbContext: DbContext
    {
        private readonly DbContextOptions<AssetsDbContext> _dbContextOption;
        public AssetsDbContext(DbContextOptions<AssetsDbContext> options): base(options) 
        {
            _dbContextOption = options;
        }

        // This is the same as defining the Table to the DB
        public DbSet<Asset_Model> Assets => Set<Asset_Model>();
    }
}
