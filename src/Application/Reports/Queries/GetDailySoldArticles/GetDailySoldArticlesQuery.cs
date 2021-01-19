using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Queries.GetDailySoldArticles
{
    public class GetDailySoldArticlesQuery : IGetDailySoldArticlesQuery
    {
        private readonly ISalesDbContext _context;

        public GetDailySoldArticlesQuery(ISalesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DailySoldArticles>> Execute()
        {
            return await _context.Sales
                .AsNoTracking()
                .GroupBy(s => s.DateTimeUtc.Date)
                .Select(g => new DailySoldArticles
                {
                    Date = g.Key,
                    ArticlesSold = g.Count()
                }).ToListAsync();
        }
    }
}
