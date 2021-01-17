using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class SalesDbContextSeed
    {
        public static async Task SeedSampleDataAsync(SalesDbContext context)
        {
            // Seed, if necessary

            await context.SaveChangesAsync();
        }
    }
}