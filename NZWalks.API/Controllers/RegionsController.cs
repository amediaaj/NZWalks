using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var regionsDomain = await _regionRepository.GetAllAsync();

            // Return DTOs (Map Domain Models to DTOs)
            return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // GET SINGLE REGION (Get Region By ID)
        // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Region Domain Model From Database
            var regionDomain = await _regionRepository.GetByIdAsync(id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(_mapper.Map<RegionDto>(regionDomain));
        }

        // Post To Create New Region
        // Post: https://localhost:portnumber/api/regions/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map/Convert DTO to Domain Model
            var regionDomain = _mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create Region
            regionDomain = await _regionRepository.CreateAsync(regionDomain);

            // Map Domain model back to DTO
            var regionDto = _mapper.Map<RegionDto>(regionDomain);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id}, regionDto);
        }

        // Update region
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) 
        {
            // Map DTO to Domain Model
            var regionDomain = _mapper.Map<Region>(updateRegionRequestDto);

            regionDomain = await _regionRepository.UpdateAsync(id, regionDomain);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Domain model back to DTO
            var regionDto = _mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }

        //Delete Region
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.DeleteAsync(id);

            if(regionDomain == null)
            {  
                return NotFound(); 
            }

            // Map Domain Model to DTO
            var regionDto = _mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }
    }
}
