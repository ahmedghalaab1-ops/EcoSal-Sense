
using EcoSal_Sense.Core.Interfaces;
using EcoSal_Sense.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSal_Sense.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SoilReading> SoilReadings { get; set; } = null!;
    }
}
