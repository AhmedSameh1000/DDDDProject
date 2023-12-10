using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public class Price : ValueObject
    {
        public Price(decimal amount, decimal currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }
        public decimal Currency { get; private set; }

        public override IEnumerable<object> GetEqualtyComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
