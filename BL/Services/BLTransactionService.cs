using Dal.Models;
using Dal.Api;
using BL.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLTransactionService : IBLTransaction
    {
        private readonly ITransaction _dalTransaction;

        public BLTransactionService(ITransaction dalTransaction)
        {
            _dalTransaction = dalTransaction;
        }

        public Task<IEnumerable<Transaction>> GetAllAsync() => _dalTransaction.GetAllAsync();
        public Task<Transaction?> GetByIdAsync(int id) => _dalTransaction.GetByIdAsync(id);
        public Task AddAsync(Transaction transaction) => _dalTransaction.AddAsync(transaction);
        public Task UpdateAsync(Transaction transaction) => _dalTransaction.UpdateAsync(transaction);
        public Task DeleteAsync(int id) => _dalTransaction.DeleteAsync(id);
    }
}
