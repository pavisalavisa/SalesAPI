using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Reports.Queries.GetDailyRevenue
{
    public interface IGetDailyRevenueQuery
    {
        Task<IEnumerable<DailyRevenueModel>> Execute();
    }
}
