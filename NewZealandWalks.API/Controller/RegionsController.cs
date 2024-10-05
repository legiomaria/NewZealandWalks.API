using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewZealandWalks.API.CustomActionFilters;
using NewZealandWalks.API.DTO;
using NewZealandWalks.API.Interfaces;
using NewZealandWalks.API.Models.Domain;
using System.Text.Json;

namespace NewZealandWalks.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionsService regionsService;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(IRegionsService regionsService, IMapper mapper,
            ILogger<RegionsController> logger)
        {
            this.regionsService = regionsService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //throw new Exception("This is a custom exception");

                var regionsDomainModel = await regionsService.GetAllAsync();

                logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomainModel)}");

                return Ok(mapper.Map<List<RegionDto>>(regionsDomainModel));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }    
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var regionDomainModel = await regionsService.GetByIdAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        [HttpPost]
        [ValidateModel]
       //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateAsync([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
              var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

              regionDomainModel = await regionsService.CreateAsync(regionDomainModel);

              return Ok(mapper.Map<RegionDto>(regionDomainModel));        
          
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                regionDomainModel = await regionsService.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<RegionDto>(regionDomainModel));  
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var regionDomainModel = await regionsService.DeleteAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
