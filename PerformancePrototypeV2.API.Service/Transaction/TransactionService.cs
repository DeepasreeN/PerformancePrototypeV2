using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.DAL.Repositories;
using PerformancePrototypeV2.API.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePrototypeV2.API.Service.Transaction
{
         public class TransactionService : ITransactionService
        {
            private readonly ITransactionRepository _transactionRepository;
            public TransactionService(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }
            public async Task<IEnumerable<TransactionDetail>> GetAllTransactionData()
            {
                var transaction = await _transactionRepository.GetAllAsync();
                //var transactionData = transaction.Take(10);
                return transaction;
            }
            public async Task<int> GetTransactionCount()
        {
            var recordCount = await _transactionRepository.GetTotalRecordCount();
            return recordCount;
        }
            public async Task<TransactionDTO> GetTransactionData(int pagesize, int skipnumber)
            {
                var transactionRecords = await _transactionRepository.GetPagedTransactionData(pagesize, skipnumber);
                var recordCount = await _transactionRepository.GetTotalRecordCount();

                var transactions = new TransactionDTO() { totalcount=recordCount,Transactiondetails=transactionRecords};
                return transactions;

            }
            public async Task<TransactionDTO> GetTransactionData(int pagesize, int skipnumber, string sortField, string sortOrder)
        {
            var transactionRecords = await _transactionRepository.GetPagedTransactionData(pagesize, skipnumber, sortField, sortOrder);
            var recordCount = await _transactionRepository.GetTotalRecordCount();

            var transactions = new TransactionDTO() { totalcount = recordCount, Transactiondetails = transactionRecords };
            return transactions;
        }
    }
    
}
