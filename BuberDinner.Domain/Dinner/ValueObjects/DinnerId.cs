using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public class DinnerId : ValueObject
    {
        public Guid value { get; }

        private DinnerId(Guid value)
        {
            this.value = value;
        }

        public static DinnerId CreateUnique()
        {
            return new DinnerId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualtyComponents()
        {
            yield return value;
        }
    }
}
