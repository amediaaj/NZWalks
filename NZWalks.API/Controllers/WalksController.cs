using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
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
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        // ctor constructor shortcut
        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this._walkRepository = walkRepository;
            this._mapper = mapper;
        }

        // CREATE Walk
        // POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map DTO to Domain Model
            var walkDomain = _mapper.Map<Walk>(addWalkRequestDto);

            await _walkRepository.CreateAsync(walkDomain);

            // Map Domain model to DTO
            var walkDto = _mapper.Map<WalkDto>(walkDomain);

            // TODO: Update this return after Get method implemented
            return Ok(walkDto);
        }

        // GET Walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModels = await _walkRepository.GetAllAsync();

            return Ok(_mapper.Map<List<WalkDto>>(walksDomainModels));
        }

        // Get Walks by Id
        // GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomain = await _walkRepository.GetByIdAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            // Mapp Domain Model to DTO
            return Ok(_mapper.Map<WalkDto>(walkDomain));
        }

        // Update Walk by Id
        // PUT: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            // DTO to Domain Model
            var walkDomain = _mapper.Map<Walk>(updateWalkRequestDTO);
            walkDomain = await _walkRepository.UpdateAync(id, walkDomain);

            if (walkDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDomain));
        }

        // Delete a Walk By Id
        // DELETE: /api/walks
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomain = await _walkRepository.DeleteAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDomain));
        }
    }
}
