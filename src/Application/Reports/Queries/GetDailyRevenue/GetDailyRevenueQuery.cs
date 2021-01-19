using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Queries.GetDailyRevenue
{
    public class GetDailyRevenueQuery : IGetDailyRevenueQuery
    {
        private readonly ISalesDbContext _context;

        public GetDailyRevenueQuery(ISalesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DailyRevenueModel>> Execute()
        {
            return await _context.Sales
                .AsNoTracking()
                .GroupBy(x => x.DateTimeUtc.Date)
                .Select(x => new DailyRevenueModel
                {
                    DateTime = x.Key,
                    Revenue = x.Sum(g => g.Price)
                }).ToListAsync();
        }
    }
}