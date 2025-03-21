﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyFD.Domain.entities
{
    public class Deposit
    {
        public string? FdNumber { get; set; }

        public int BankAccout { get; set; }

        public DateOnly DepositDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        
        public decimal DepositAmount { get; set; }

        public DateOnly MaturityDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(1));

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
