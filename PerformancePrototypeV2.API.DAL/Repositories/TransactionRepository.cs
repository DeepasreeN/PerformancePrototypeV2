using Microsoft.EntityFrameworkCore;
using PerformancePrototypeV2.API.DAL;
using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.DAL.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace PerformancePrototypeV2.API.DAL.Repositories
{
    public class TransactionRepository : Repository<TransactionDetail>, ITransactionRepository
    {
        private readonly InformationDBContext _context;
        public TransactionRepository(InformationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TransactionDetail>> GetPagedTransactionData(int pageSize, int skipRecordCount)
        {
            var transactiondata = await _context.TransactionDetails
                            .OrderBy(x=>x.Id)
                            .Skip(skipRecordCount)
                            .Take(pageSize)
                            .ToListAsync();
            return transactiondata;
        }

        public async Task<int> GetTotalRecordCount()
        {
            var count = await _context.TransactionDetails.CountAsync();
            return count;
        }
    }
}
