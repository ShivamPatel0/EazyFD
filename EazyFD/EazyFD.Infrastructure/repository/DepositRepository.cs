using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EazyFD.Domain.entities;
using EazyFD.Domain.repository;
using LiteDB.Async;

namespace EazyFD.Infrastructure.repository
{
    class DepositRepository : IDepositRepository
    {
        public async Task<int> AddDeposit(Deposit deposit)
        {
            using var context = new LiteDatabaseAsync(@"EazyFD.db");
            var deposits = context.GetCollection<Deposit>("deposits");
            await deposits.InsertAsync(deposit);
            return 1;
        }

        public async Task<List<Deposit>> GetAllDeposits()
        {
            using var context = new LiteDatabaseAsync(@"EazyFD.db");
            var deposits = context.GetCollection<Deposit>("deposits");
            return await deposits.Query().ToListAsync();
        }
    }
}
