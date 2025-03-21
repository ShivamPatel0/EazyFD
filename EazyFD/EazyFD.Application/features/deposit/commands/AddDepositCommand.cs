using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyFD.Application.features.deposit.commands
{
    public class AddDepositCommand : IRequest<int>
    {
        public string? FdNumber { get; set; }

        [Required(ErrorMessage = "Please select valid bank account")]
        public int BankAccout { get; set; }

        [Required(ErrorMessage = "Please select valid deposit date")]
        public DateOnly DepositDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required(ErrorMessage = "Please select valid deposit amount")]
        public decimal DepositAmount { get; set; }

        [Required(ErrorMessage = "Please select valid maturity date.")]
        public DateOnly MaturityDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(1));

        [Required(ErrorMessage = "Please select valid maturity amount.")]
        public decimal MaturityAmount { get; set; }

        public string? Remarks { get; set; }

        public List<DepositAmountSource>? DepositAmountSources { get; set; }

    }

    public class DepositAmountSource
    {
        public string? Source { get; set; }
        public string? AccountDetails { get; set; }
        public decimal Amount { get; set; }

    }
}
