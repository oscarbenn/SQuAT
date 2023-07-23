using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQuATStation;

namespace SQuATStation.Data
{
    public class SQuATStationContext : DbContext
    {
        public SQuATStationContext (DbContextOptions<SQuATStationContext> options)
            : base(options)
        {
        }

        public DbSet<SQuATStation.TestCase> TestCase { get; set; } = default!;
    }
}
