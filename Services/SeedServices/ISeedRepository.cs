using Common;
using System.Threading.Tasks;

namespace Services.SeedServices
{
    public interface ISeedRepository:IScopedDependency
    {
        Task SeedAsync(); 
    }
}
