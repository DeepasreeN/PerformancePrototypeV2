using Microsoft.AspNetCore.Mvc;
using PerformancePrototypev2.API.Common;
using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.Service.DTOs;
using PerformancePrototypeV2.API.Service.Transaction;

namespace PerformancePrototypeV2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                return new APIResponse<IEnumerable<TransactionDetail>>
                {
                    Success = false,
                    Message = "Transaction not found",
                    Data = null
                };
            }

            return new APIResponse<IEnumerable<TransactionDetail>>
            {
                Success = true,
                Message = "Transactions retrieved successfully",
                Data = data
            };

        }

        [HttpGet("page")]
        public async Task<APIResponse<TransactionDTO>> GetByPage(int pageSize,int skipNumber=0)
        {

            var data = await _transactionService.GetTransactionData(pageSize, skipNumber);
            if (data == null)
            {
                return new APIResponse<TransactionDTO>
                {
                    Success = false,
                    Message = "Transaction not found",
                    Data = null
                };
            }

            return new APIResponse<TransactionDTO>
            {
                Success = true,
                Message = "Transactions retrieved successfully",
                Data = data
            };

        }
        [HttpGet("count")]
        public  APIResponse<int> GetTotalCount()
        {

            var data = 100;
            if (data == 0)
            {
                return new APIResponse<int>
                {
                    Success = false,
                    Message = "Transaction not found",
                    Data = data
                };
            }

            return new APIResponse<int>
            {
                Success = true,
                Message = "Transactions retrieved successfully",
                Data = data
            };

        }

    }
}
