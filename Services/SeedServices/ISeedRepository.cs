using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SeedServices
{
    public interface ISeedRepository
    {
        Task SeedAsync(); 
    }
}
