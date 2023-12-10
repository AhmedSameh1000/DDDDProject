using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public class MenuItem : Entity<MenuItemId>
    {
        private MenuItem(MenuItemId menuItemId, string name, string description)
            : base(menuItemId)
        {
            this.Name = name;
            this.Description = description;
        }

        public static MenuItem Create(string Name, string Description)
        {
            return new MenuItem(MenuItemId.CreateUnique(), Name, Description);
        }

        public string Name { get; }
        public string Description { get; }
    }
}
