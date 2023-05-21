using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    //https://locahost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {   
            // Get Data From Database - Domain models
            List<Region> regions = _dbContext.Regions.ToList();

            //Map Domain Models to DTOs
            List<RegionDto> regionDto = new List<RegionDto>();
            foreach (Region region in regions)
            {
                regionDto.Add(new RegionDto() 
                { 
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl

                });
            }

            return Ok(regions);
        }

        //GET single region
        //https://locahost:port/api/regions/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            // The find only takes a primary key, so it can only be used for id
            // Get Region Doamin Mode lFrom Database
            var region = _dbContext.Regions.FirstOrDefault(p => p.Id == id);
            if(region==null) return NotFound();
            //Map Region doemain model to region DTO
            var regionDto = new RegionDto() 
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            //Return DTO back to client
            return Ok(regionDto);  
        }

        // POST: Create a New region
        //https://locahost:port/api/regions
        [HttpPost]
        public IActionResult Create(AddRegionRequestDto addRegionRequestDto) {
            var regionDomainModel = new Region()
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //use doamin model to create region
            _dbContext.Regions.Add(regionDomainModel);
            _dbContext.SaveChanges();

            // Map Domain model back to DTO

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(Get), new { id = regionDto.Id }, regionDto);
        
        }

        //Update region
        //PUT:https://localhost:portnumber/api/regions/
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) {
            //check if region exist
            var regionDomainModel = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomainModel == null) return NotFound();
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            _dbContext.SaveChanges();

            var regionDto = new RegionDto() {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
                Code = regionDomainModel.Code,

            };
            return Ok(regionDto);

        }

        //Delete region
        //DeLETE: https//localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            Region? regionDomainModel = _dbContext.Regions.FirstOrDefault(p => p.Id == id);

            if (regionDomainModel == null) 
            { 
                return NotFound();
            }

            //Delete region
            _dbContext.Regions.Remove(regionDomainModel);
            _dbContext.SaveChanges();

            //return delete Regionback
            //map Domain to DTO
            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
                Code = regionDomainModel.Code,

            };
            return Ok(regionDto);
        }
    }
}
