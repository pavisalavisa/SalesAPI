using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Reports.Queries.GetRevenuePerArticle
{
    public interface IGetRevenuePerArticleQuery
    {
        Task<IEnumerable<RevenuePerArticle>> Execute();
    }
}
