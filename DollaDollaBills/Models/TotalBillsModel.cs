using System.Collections.Generic;

namespace DollaDollaBills.Models
{
    public class TotalBillsModel
    {

        public TotalBillsModel()
        {
            Receipts = new List<Receipt>();
        }
        public int Id { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; } 
        public decimal Total { get; set; }
    }
}