using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Queries.GetRevenuePerArticle
{
    public class GetRevenuePerArticleQuery : IGetRevenuePerArticleQuery
    {
        private readonly ISalesDbContext _context;

        public GetRevenuePerArticleQuery(ISalesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RevenuePerArticle>> Execute()
        {
            // Nice conversation starter :) 
            // What is AsNoTracking and why Jon P Smith advocates for setting it as default
            return await _context.Sales.AsNoTracking()
                .GroupBy(s => s.ArticleNumber)
                .Select(g => new RevenuePerArticle
                {
                    ArticleNumber = g.Key,
                    Revenue = g.Sum(x => x.Price)
                }).ToListAsync();
        }
    }
}