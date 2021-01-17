using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ISalesDbContext
    {
        // TODO: Add entity repositories

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
