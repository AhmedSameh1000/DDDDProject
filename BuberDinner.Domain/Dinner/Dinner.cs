using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public class Dinner : AggregateRoot<DinnerId>
    {
        public Dinner(DinnerId Id)
            : base(Id) { }
    }
}
