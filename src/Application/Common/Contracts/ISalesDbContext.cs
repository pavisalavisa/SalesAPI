using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Contracts
{
    public interface ISalesDbContext
    {
        // Nice conversation starter :)
        // Should the application layer know about ORM
        DbSet<Sale> Sales { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
