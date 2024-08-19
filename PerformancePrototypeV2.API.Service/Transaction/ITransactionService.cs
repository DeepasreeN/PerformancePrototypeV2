using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePrototypeV2.API.Service.Transaction
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDetail>> GetAllTransactionData();
        Task<int> GetTransactionCount();
        Task<TransactionDTO> GetTransactionData(int pagesize, int skipnumber);
        Task<TransactionDTO> GetTransactionData(int pagesize, int skipnumber, string sortField , string sortOrder);
    }
}
