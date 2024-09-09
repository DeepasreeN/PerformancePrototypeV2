using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.DAL.Repositories;
using PerformancePrototypeV2.API.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            public async Task<FileStream> DownloadTransactiondata()
            {
                var transaction = await _transactionRepository.GetAllAsync();
                var transactionData = transaction.Take(20);
                var filedata = await convertToCSV(transactionData);
                return filedata;
            }

            private async Task<FileStream> convertToCSV(IEnumerable<TransactionDetail> transactiondata)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Exports");
                var fileName = "data.csv";
                var fullPath = Path.Combine(filePath, fileName);

                // Ensure the directory exists
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // Generate and write CSV to file using FileStream
                using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    // Get the properties of the first object (to use as headers)
                    var properties = typeof(TransactionDetail).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                    // Generate headers dynamically from property names
                    var headers = string.Join(",", properties.Select(p => p.Name));
                    await writer.WriteLineAsync(headers);

                    // Generate rows dynamically from property values
                    foreach (var item in transactiondata)
                    {
                        var rowValues = string.Join(",", properties.Select(p => p.GetValue(item)?.ToString()));
                        await writer.WriteLineAsync(rowValues);
                    }
            }

            // Return the CSV file for download
            var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            return stream;
        }

    }
    
}
