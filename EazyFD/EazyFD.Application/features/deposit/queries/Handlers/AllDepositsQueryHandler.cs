using EazyFD.Application.features.deposit.queries.dtos;
using EazyFD.Domain.repository;
using MediatR;

namespace EazyFD.Application.features.deposit.queries.Handlers
{
    sealed class AllDepositsQueryHandler : IRequestHandler<AllDepositsQuery, List<AllDepositQueryDTO>>
    {
        private readonly IDepositRepository _depositRepository;

        public AllDepositsQueryHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }
        public async Task<List<AllDepositQueryDTO>> Handle(AllDepositsQuery request, CancellationToken cancellationToken)
        {
            var response = new List<AllDepositQueryDTO>();
            var deposits = await _depositRepository.GetAllDeposits();

            response.AddRange(deposits.Select(d => new AllDepositQueryDTO
            {
                FdNumber = d.FdNumber,
                BankAccout = d.BankAccout,
                DepositDate = d.DepositDate,
                DepositAmount = d.DepositAmount,
                MaturityDate = d.MaturityDate,
                MaturityAmount = d.MaturityAmount,
                Remarks = d.Remarks,
                DepositAmountSourcesDto = d.DepositAmountSources?.Select(das => new DepositAmountSourceDto
                {
                    Source = das.Source,
                    AccountDetails = das.AccountDetails,
                    Amount = das.Amount
                }).ToList()
            }));
            return response;
        }
    }
}
