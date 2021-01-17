using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SalesDbContext : DbContext, ISalesDbContext
    {
        public SalesDbContext(DbContextOptions options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // Run interceptors, dispatch events, ...
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}