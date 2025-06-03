using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Models
{
    class Record
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // 收入/支出
        public string Description { get; set; }
    }
}
