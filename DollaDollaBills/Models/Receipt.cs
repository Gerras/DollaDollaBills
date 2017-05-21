using System;

namespace DollaDollaBills.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
        public string User { get; set; }
        public DateTime DateAdded { get; set; }
        public string Desription { get; set; }
    }
}