using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public class MenuItemId : ValueObject
    {
        public Guid value { get; }

        private MenuItemId(Guid value)
        {
            this.value = value;
        }

        public static MenuItemId CreateUnique()
        {
            return new MenuItemId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualtyComponents()
        {
            yield return value;
        }
    }
}
