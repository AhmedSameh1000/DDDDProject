using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public class AverageRating : ValueObject
    {
        private AverageRating(double value, int newRating)
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

        public static AverageRating Create(double rating = 0, int newRating = 0)
        {
            return new AverageRating(rating, newRating);
        }

        public void AddNewrating(Rating rating)
        {
            Value = ((Value * newRating) * rating.Value) / ++newRating;
        }
    }
}
