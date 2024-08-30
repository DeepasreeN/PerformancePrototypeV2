using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformancePrototypev2.API.Common;
using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.Service.DTOs;
using PerformancePrototypeV2.API.Service.Transaction;

namespace PerformancePrototypeV2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<APIResponse<IEnumerable<TransactionDetail>>> Get()
        {
            
            var data = await _transactionService.GetAllTransactionData();
            if (data == null)
            {
                return new APIResponse<IEnumerable<TransactionDetail>>(System.Net.HttpStatusCode.NotFound, "Transaction not found.", null);
               
            }

            return new APIResponse<IEnumerable<TransactionDetail>>(data, "Transactions retrieved successfully");
           
        }

        [HttpGet("page")]
        public async Task<APIResponse<TransactionDTO>> GetByPage(int pageSize,int skipNumber=0,string sortField="Id",string sortOrder="asc")
        {

            var data = await _transactionService.GetTransactionData(pageSize, skipNumber,sortField,sortOrder);
            if (data == null)
            {
                return new APIResponse<TransactionDTO>(System.Net.HttpStatusCode.NotFound, "Transaction not found.", null);
            }

            return new APIResponse<TransactionDTO>(data, "Transactions retrieved successfully");
          
        }
        [HttpGet("count")]
        public async Task<APIResponse<int>> GetTotalCount()
        {
            
            var data = await _transactionService.GetTransactionCount();
            if (data == 0)
            {
                return new APIResponse<int>(System.Net.HttpStatusCode.NotFound, "Transaction not found.", null);
               
            }

            return new APIResponse<int>(data, "Transactions retrieved successfully");
         
        }

    }
}
