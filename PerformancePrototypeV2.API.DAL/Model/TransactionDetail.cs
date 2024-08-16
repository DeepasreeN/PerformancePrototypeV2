using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePrototypeV2.API.DAL.Model
{
    public class TransactionDetail
    {
        [Key]
        public long Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }
        public string? StoreLocation { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductType { get; set; }
        public string? ProductDetail { get; set; }
        public string? Month { get; set; }
              
     }
}
