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
        private IMapper mapper;

        // ctor constructor shortcut
        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            WalkRepository = walkRepository;
            this.mapper = mapper;
        }

        public IWalkRepository WalkRepository { get; }

        // CREATE Walk
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> CreateAsyc([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await WalkRepository.CreateAsync(walkDomainModel);

            // Map Domain model to DTO
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            // TODO: Update this return after Get method implemented
            return Ok(walkDto);
        }

        // GET Walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var walksDomainModels = await WalkRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModels));
        }
    }
}
