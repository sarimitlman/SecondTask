using Dal.Models;
using Dal.Api;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Api;

namespace BL.Services
{
    public class BLPaymentService : IBLPayment
    {
        private readonly IPayment _dalPayment;

        public BLPaymentService(IPayment dalPayment)
        {
            _dalPayment = dalPayment;
        }

        public async Task<decimal> GetSumAsync()
        {
            var allPayments = await _dalPayment.GetAllAsync();
            return allPayments.Sum(p => p.Amount);

        }

        public async Task<decimal> GetSumByUserIdAsync(int userId)
        {
            var allPayments = await _dalPayment.GetAllAsync();
            return allPayments.Where(p => p.UserId == userId).Sum(p => p.Amount);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _dalPayment.GetAllAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllByUserIdAsync(int userId)
        {
            var allPayments = await _dalPayment.GetAllAsync();
            return allPayments.Where(p => p.UserId == userId);
        }
        public async Task<(decimal current, decimal previous, double percentChange)> GetPaymentsSummaryAsync()
        {
            var allPayments = await _dalPayment.GetAllAsync();
            var now = DateTime.Now;
            var startOfThisMonth = new DateTime(now.Year, now.Month, 1);
            var startOfLastMonth = startOfThisMonth.AddMonths(-1);

            var currentSum = allPayments
                .Where(p => p.PaymentDate >= startOfThisMonth)
                .Sum(p => p.Amount);

            var previousSum = allPayments
                .Where(p => p.PaymentDate >= startOfLastMonth && p.PaymentDate < startOfThisMonth)
                .Sum(p => p.Amount);

            double percentChange = previousSum == 0 ? 0 : ((double)(currentSum - previousSum) / (double)previousSum) * 100.0;

            return (currentSum, previousSum, percentChange);
        }
        public Task<Payment?> GetByIdAsync(int id) => _dalPayment.GetByIdAsync(id);
        public Task AddAsync(Payment payment) => _dalPayment.AddAsync(payment);
        public Task UpdateAsync(Payment payment) => _dalPayment.UpdateAsync(payment);
        public Task DeleteAsync(int id) => _dalPayment.DeleteAsync(id);
    }
}