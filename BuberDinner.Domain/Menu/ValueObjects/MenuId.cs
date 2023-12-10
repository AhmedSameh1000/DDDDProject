using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public class MenuId : ValueObject
    {
        public Guid value { get; }

        private MenuId(Guid value)
        {
            this.value = value;
        }

        public static MenuId CreateUnique()
        {
            return new MenuId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualtyComponents()
        {
            yield return value;
        }
    }
}
