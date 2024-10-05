using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewZealandWalks.API.CustomActionFilters;
using NewZealandWalks.API.DTO;
using NewZealandWalks.API.Interfaces;
using NewZealandWalks.API.Models.Domain;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace NewZealandWalks.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkService walkService;
        private readonly IMapper mapper;
        

        public WalksController(IWalkService walkService, IMapper mapper)
            
        {
            this.walkService = walkService;
            this.mapper = mapper;
           
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {      
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                walkDomainModel = await walkService.CreateAsync(walkDomainModel);

                return Ok(mapper.Map<WalkDto>(walkDomainModel));
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
           
        {      
                var walksDomainModel = await walkService.GetAllAsync(filterOn, filterQuery, sortBy,
               isAscending ?? true, pageNumber, pageSize);

            // Create an exception
            throw new Exception("This is a new exception");

                return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
                    
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walkDomainModel = await walkService.GetByIdAsync(id);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {      
              var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

              walkDomainModel = await walkService.UpdateAsync(id, walkDomainModel);

              if (walkDomainModel == null)
              {
                 return NotFound();
              }

                return Ok(mapper.Map<WalkDto>(walkDomainModel));      
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedwalkDomainModel = await walkService.DeleteAsync(id);

            if(deletedwalkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(deletedwalkDomainModel));
        }
    }
}
