using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    //https://locahost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            // Get Data From Database - Domain models
            List<Region> regions = await regionRepository.GetAllAsync();

            //Map Domain Models to DTOs
            var regionDto = mapper.Map<List<RegionDto>>(regions);

            return Ok(regionDto);
        }

        //GET single region
        //https://locahost:port/api/regions/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            // The find only takes a primary key, so it can only be used for id
            // Get Region Doamin Mode lFrom Database
            var region = await regionRepository.GetByIdAsync(id);
            if(region==null) return NotFound();
            //Map Region doemain model to region DTO
            var regionDto = mapper.Map<RegionDto>(region);
            //Return DTO back to client
            return Ok(regionDto);  
        }

        // POST: Create a New region
        //https://locahost:port/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create(AddRegionRequestDto addRegionRequestDto) 
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            //use doamin model to create region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain model back to DTO

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(Get), new { id = regionDto.Id }, regionDto);


        }

        //Update region
        //PUT:https://localhost:portnumber/api/regions/
        [HttpPut]
        [Route("{id}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            //Map DTO to Doamin model
            Region? regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            //check if region exist
            
            if (regionDomainModel == null) return NotFound();

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            
            return Ok(regionDto);

        }

        //Delete region
        //DeLETE: https//localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Region? regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null) 
            { 
                return NotFound();
            }

            //return delete Regionback
            //map Domain to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }
    }
}
