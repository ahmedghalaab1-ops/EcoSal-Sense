using EcoSal_Sense.Core.Interfaces;
using EcoSal_Sense.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSal_Sense.Data.Repository
{
    public class SoilRepository : ISoilRepository
    {
        private readonly AppDbContext _context;

        public SoilRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReadingAsync(SoilReading reading)
        {
            await _context.SoilReadings.AddAsync(reading);
            await _context.SaveChangesAsync();
        }

        public async Task<SoilReading?> GetLatestReadingAsync()
        {
            return await _context.SoilReadings
                .OrderByDescending(r => r.Timestamp)
                .FirstOrDefaultAsync();
        }
    }
}
