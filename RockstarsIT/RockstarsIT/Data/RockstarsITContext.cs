using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RockstarsIT.Models;

namespace RockstarsIT.Data
{
    public class RockstarsITContext : DbContext
    {
        public RockstarsITContext (DbContextOptions<RockstarsITContext> options)
            : base(options)
        {
        }

        public DbSet<RockstarsIT.Models.Squads> Squads { get; set; } = default!;
    }
}
