﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            this.walkRepository = walkRepository;
        }

        public IMapper Mapper { get; }

        //CREATE Walk
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto) 
        {
            //Map DTO to Domain Model
            var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateAsync(walkDomainModel);
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));

        }

        // GET Walks
        // GET /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            var walksDomainModel = await walkRepository.GetAllAsync();

            //Map domain to dto
            return Ok(_mapper.Map<List<WalkDto>>(walksDomainModel));
        
        }

        // Get walk by Id
        //GET: /api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if(walkDomainModel == null)return NotFound();
            //Map doamin to dto
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }

        // Update Walk By id
        // PUT : /api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto) {

            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
            if(walkDomainModel==null)return NotFound();
            //map 
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
            
        }

        //Delete Walk by Id
        // DELETE: /api/Walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        { 
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);
            if (deletedWalkDomainModel == null) return NotFound();
            //Map domain to dto
            return Ok(_mapper.Map<WalkDto>(deletedWalkDomainModel));
        
        }

    }
}
