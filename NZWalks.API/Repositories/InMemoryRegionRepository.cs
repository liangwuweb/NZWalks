using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository //: //IRegionRepository
    {
        public InMemoryRegionRepository() 
        { 
        
        
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "Sam",
                    Name = "Sameer Resion Name"
                }
            };
        }
    }
}
