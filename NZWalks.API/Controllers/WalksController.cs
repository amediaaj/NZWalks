using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        // ctor constructor shortcut
        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

  

        // CREATE Walk
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map DTO to Domain Model
            var walkDomain = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomain);

            // Map Domain model to DTO
            var walkDto = mapper.Map<WalkDto>(walkDomain);

            // TODO: Update this return after Get method implemented
            return Ok(walkDto);
        }

        // GET Walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModels = await walkRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModels));
        }

        // Get Walks by Id
        // GET: /api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.GetByIdAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            // Mapp Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }

    }
}
