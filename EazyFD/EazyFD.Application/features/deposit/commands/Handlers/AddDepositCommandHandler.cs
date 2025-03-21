using EazyFD.Domain.entities;
using EazyFD.Domain.repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyFD.Application.features.deposit.commands.Handlers
{
    sealed class AddDepositCommandHandler : IRequestHandler<AddDepositCommand, int>
    {
        private readonly IDepositRepository _depositRepository;

        public AddDepositCommandHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }
        public async Task<int> Handle(AddDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = new Deposit
            {
                FdNumber = request.FdNumber,
                BankAccout = request.BankAccout,
                DepositDate = request.DepositDate,
                DepositAmount = request.DepositAmount,
                MaturityDate = request.MaturityDate,
                MaturityAmount = request.MaturityAmount,
                Remarks = request.Remarks,
                DepositAmountSources = request.DepositAmountSources?.Select(das => new EazyFD.Domain.entities.DepositAmountSource
                {
                    Source = das.Source,
                    AccountDetails = das.AccountDetails,
                    Amount = das.Amount
                }).ToList()
            };
            return await _depositRepository.AddDeposit(deposit);
        }
    }
}
