using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1ExpenseManagment.Business
{
    public class ExpenseItem
    {
        public string Date { get; set; } 
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public ExpenseItem(string date, string type, string description, decimal cost)
        {
            Date = date;
            Type = type;
            Description = description;
            Cost = cost;
        }

        public string GetDisplayText()
        {
            return Date + " " + Type + " " + Description + " " + "($" + Cost + ")";
        }
    }

}
