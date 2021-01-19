using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Reports.Queries.GetDailySoldArticles
{
    public interface IGetDailySoldArticlesQuery
    {
        Task<IEnumerable<DailySoldArticles>> Execute();
    }
}