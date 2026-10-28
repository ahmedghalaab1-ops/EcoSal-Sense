using EcoSal_Sense.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSal_Sense.Core.Interfaces
{
    public interface ISoilRepository
    {
        Task AddReadingAsync(SoilReading reading);
        Task<SoilReading?> GetLatestReadingAsync();
    }
}
