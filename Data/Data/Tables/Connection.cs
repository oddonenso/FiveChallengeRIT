using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class Connection:DbContext
    {
        public Connection(DbContextOptions<Connection> options)
          : base(options)
        {
        }
        public DbSet<DrillBlock> DrillBlock { get; set; }
        public DbSet<DrillBlockPoint> DrillBlockPoint { get; set; }
        public DbSet<Hole> Hole { get; set; }
        public DbSet<HolePoint> HolePoint { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=111;Database=SuperMapRIT;");
        }
    }
}
