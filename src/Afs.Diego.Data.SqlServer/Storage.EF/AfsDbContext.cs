using Afs.Diego.Data.Entities;
using Afs.Diego.Data.SqlServer.Storage.EF.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Afs.Diego.Data.SqlServer.Storage.EF
{
    public class AfsDbContext : DbContext
    {
        public AfsDbContext(DbContextOptions<AfsDbContext> options): base(options)
        {
        }

        public DbSet<ApiRequest> ApiRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mappings
            new ApiRequestMap(modelBuilder.Entity<ApiRequest>());
        }
    }
}
