using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview
{
    public class MenuReview : AggregateRoot<MenuReviewId>
    {
        public MenuReview(MenuReviewId Id)
            : base(Id) { }
    }
}
