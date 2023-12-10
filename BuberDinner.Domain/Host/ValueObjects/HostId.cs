using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects
{
    public class HostId : ValueObject
    {
        public Guid value { get; }

        private HostId(Guid value)
        {
            this.value = value;
        }

        public static HostId CreateUnique()
        {
            return new HostId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualtyComponents()
        {
            yield return value;
        }
    }
}
