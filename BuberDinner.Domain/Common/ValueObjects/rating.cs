using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public class Rating : ValueObject
    {
        public Rating(double value, int newRating)
        {
            this.newRating = newRating;

            this.Value = value;
        }

        public double Value { get; private set; }
        public int newRating { get; private set; }

        public override IEnumerable<object> GetEqualtyComponents()
        {
            yield return Value;
            yield return newRating;
        }
    }
}
