using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EazyFD.Domain.entities;
using EazyFD.Domain.repository;
using LiteDB.Async;

namespace EazyFD.Infrastructure.repository
{
    class DepositRepository : IDepositRepository
    {
        private readonly LiteDatabaseAsync _context;
        public DepositRepository()
        {
            _context = new LiteDatabaseAsync(@"EazyFD.db"); //LiteDB
        }
        public async Task<int> AddDeposit(Deposit deposit)
        {
            var deposits = _context.GetCollection<Deposit>("deposits");
            await deposits.InsertAsync(deposit);
            return 1;
        }

        public async Task<List<Deposit>> GetAllDeposits()
        {
            var deposits = _context.GetCollection<Deposit>("deposits");
            return await deposits.Query().ToListAsync();
        }
    }
}
