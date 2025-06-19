using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using AutoMapper;

namespace NZWalks.API.Controllers
{
    // Base route for this controller: /api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        // Constructor with dependency injection
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: /api/regions
        // Returns all regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // Fetch domain models from the repository
            var regionsDomain = await regionRepository.GetAllRegionsAsync();

            // Convert domain models to DTOs using AutoMapper
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            // Return the list of regions
            return Ok(regionsDto);
        }

        // GET: /api/regions/{id}
        // Returns a region by ID
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            // Fetch the domain model by ID
            var regionDomain = await regionRepository.GetRegionByIdAsync(id);

            // Return 404 if not found
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Convert domain model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            // Return the region DTO
            return Ok(regionDto);
        }

        // POST: /api/regions
        // Adds a new region
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map incoming DTO to a domain model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // Save the new region to the database
            regionDomainModel = await regionRepository.CreateRegionAsync(regionDomainModel);

            // Map saved domain model back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            // Return 201 with location header pointing to the newly created region
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        // PUT: /api/regions/{id}
        // Updates an existing region
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map update DTO to domain model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            // Update the region in the database
            regionDomainModel = await regionRepository.UpdateRegionAsync(id, regionDomainModel);

            // Return 404 if region not found
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Map updated domain model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            // Return updated DTO
            return Ok(regionDto);
        }

        // DELETE: /api/regions/{id}
        // Deletes a region by ID
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            // Delete the region from the repository
            var regionDomainModel = await regionRepository.DeleteRegionAsync(id);

            // Return 404 if region not found
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Map deleted domain model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            // Return deleted region DTO
            return Ok(regionDto);
        }
    }
}
