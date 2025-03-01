using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/difficulties
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultiesController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IMapper _mapper;
        
        public DifficultiesController(NZWalksDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET ALL Difficulties
        // GET: https://localhost:portnumber/api/difficulties
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var difficultiesDomain = await _context.Difficulties.ToListAsync();

            // Return DTOs (Map Domain Models to DTOs)
            return Ok(_mapper.Map<List<DifficultyDto>>(difficultiesDomain));
        }
    }
}
