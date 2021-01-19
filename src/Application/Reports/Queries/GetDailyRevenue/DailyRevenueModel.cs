using System;

namespace Application.Reports.Queries.GetDailyRevenue
{
    public class DailyRevenueModel
    {
        public DateTime DateTime { get; set; }
        public decimal Revenue { get; set; }
    }
}