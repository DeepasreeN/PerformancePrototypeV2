using PerformancePrototypeV2.API.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePrototypeV2.API.Service.DTOs
{
    public class TransactionDTO
    {
        public int totalcount { get; set; }
        public List<TransactionDetail>? Transactiondetails { get; set; }
    }
}
