using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new List<MenuSection>();
        private readonly List<DinnerId> _dinnerIds = new List<DinnerId>();
        private readonly List<MenuReviewId> _menuReviewIds = new List<MenuReviewId>();

        private Menu(
            MenuId Id,
            string name,
            string description,
            HostId hostId,
            DateTime CreatedDate,
            DateTime UpdatedDate
        )
            : base(Id)
        {
            this.Name = name;

            this.Description = description;
            this.hostId = hostId;
            this.CreatedDateTime = CreatedDate;
            this.UpdateDateTime = UpdatedDate;
        }

        public static Menu Create(string name, string description, HostId hostId)
        {
            return new Menu(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }

        public IReadOnlyList<MenuSection> sections => _sections.AsReadOnly();
        public HostId hostId { get; }
        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdateDateTime { get; }
    }
}
