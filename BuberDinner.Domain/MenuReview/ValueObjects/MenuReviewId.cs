using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid value { get; }

        private MenuReviewId(Guid value)
        {
            this.value = value;
        }

        public static MenuReviewId CreateUnique()
        {
            return new MenuReviewId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualtyComponents()
        {
            yield return value;
        }
    }
}
