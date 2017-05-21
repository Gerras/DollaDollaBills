using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DollaDollaBills.Models
{
    public class SpendingModel
    {
        public int Id { get; set; }
        public int MonthlySpendingLimit { get; set; }
        public int MonthlyIncome { get; set; }
    }
}