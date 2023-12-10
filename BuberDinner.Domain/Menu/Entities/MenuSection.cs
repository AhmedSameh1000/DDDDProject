using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        private MenuSection(MenuSectionId Id, string Name, string description)
            : base(Id)
        {
            this.Name = Name;
            this.Description = description;
        }

        public static MenuSection Create(string Name, string Description)
        {
            return new MenuSection(MenuSectionId.CreateUnique(), Name, Description);
        }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private readonly List<MenuItem> _items = new List<MenuItem>();
        public string Name { get; }
        public string Description { get; }
    }
}
