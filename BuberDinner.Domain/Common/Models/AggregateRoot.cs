using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.Models
{
    public abstract class AggregateRoot<TID> : Entity<TID>
        where TID : notnull
    {
        protected AggregateRoot(TID Id)
            : base(Id) { }
    }
}
