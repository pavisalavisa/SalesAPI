using System;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    // Anemic model for the sake of simplicity
    // Nice conversation starter about DDD :)
    public class Sale : BaseEntity
    {
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public DateTime DateTimeUtc { get; set; }
    }
}
