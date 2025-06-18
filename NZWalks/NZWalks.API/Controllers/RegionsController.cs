using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Controllers
{
    // http://localhost:5000/api/Regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Get: http://localhost:5000/api/Regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            //Get Data From Database - Domain Models

            var regionsDomain = await dbContext.Regions.ToListAsync(); // Fetch all regions from the database

            // Map Domain Models to DTOs

            var regionsDto = new List<RegionDto>();

            foreach (var regionDomain in regionsDomain)
            {
                // Create a new RegionDto for each region

                var regionDto = new RegionDto
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                };
                regionsDto.Add(regionDto); // Add the DTO to the list
            }

            // Return DTOs 
            return Ok(regionsDto);
        }

        // Get: http://localhost:5000/api/Regions/{id}
        [HttpGet]
        [Route("{id:guid}")] // Route to get a specific region by ID
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            //Get Data From Database - Domain Model

            var regionDomain = await dbContext.Regions.FindAsync(id); // Fetch the region by ID
            if (regionDomain == null)
            {
                return NotFound(); // Return 404 if the region is not found
            }

            //Map/ Convert Domain Model to DTO

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            // Return DTO back to the client
            return Ok(regionDomain);
        }

        // Post to create a new region
        // Post: http://localhost:5000/api/Regions

        [HttpPost]

        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert DTO to Domain Model

            var regionDomainModel = new Region
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //use the DbContext to save the new region to the database
            await dbContext.Regions.AddAsync(regionDomainModel); // Add the new region to the DbContext
            await dbContext.SaveChangesAsync(); // Save changes to the database

            // Map Domain Model to DTO

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };


            return CreatedAtAction(nameof(GetRegionById), new { id = regionDomainModel.Id }, regionDomainModel);
        }

        // update an existing region
        // Put: http://localhost:5000/api/Regions/{id}
        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Check if the region exists in the database
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); // Find the region by ID

            if (regionDomainModel == null)
            {
                return NotFound(); // Return 404 if the region is not found
            }

            // Map/Convert DTO to Domain Model

            regionDomainModel.Name = updateRegionRequestDto.Name; // Update the name
            regionDomainModel.Code = updateRegionRequestDto.Code; // Update the code
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl; // Update the image URL

            // Save the updated region back to the database

            dbContext.Regions.Update(regionDomainModel); // Update the region in the DbContext
            await dbContext.SaveChangesAsync();

            //convert Domain Model to DTO

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto); // Return the updated region DTO
        }
        // Delete Region
        // Delete: http://localhost:5000/api/Regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            //Check if the region exists in the database

            var regionDomainModel =await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); // Find the region by ID
            if (regionDomainModel == null)
            {
                return NotFound(); // Return 404 if the region is not found
            }
            // Delete the region from the database

            dbContext.Regions.Remove(regionDomainModel); // Remove the region from the DbContext
            await dbContext.SaveChangesAsync(); // Save changes to the database

            //Return Delete Response
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto); 

        }
    }
}
