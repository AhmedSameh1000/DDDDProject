using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public class Host : AggregateRoot<HostId>
    {
        public Host(HostId Id)
            : base(Id) { }
    }
}
