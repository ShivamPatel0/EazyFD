using EazyFD.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyFD.Domain.repository
{
    public interface IDepositRepository
    {
        Task<int> AddDeposit(Deposit deposit);
        Task<List<Deposit>> GetAllDeposits();
    }
}
