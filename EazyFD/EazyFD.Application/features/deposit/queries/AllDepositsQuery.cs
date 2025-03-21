using EazyFD.Application.features.deposit.queries.dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyFD.Application.features.deposit.queries
{
    public class AllDepositsQuery : IRequest<List<AllDepositQueryDTO>>
    {
    }
}
