using JobQuest.Core.DTOs;
using JobQuest.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobQuest_backend.Controllers
{
    [Route("api/Advertisement")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        
        
        [HttpGet("ShowAdvertisements")]
        public async Task<ActionResult<IEnumerable<ShowAdvertisementDto>>> ShowAdvertisements()
        {
            var advertisements=await _advertisementService.ShowAdvertisementsAsync();
            return Ok(advertisements);
        }

        [HttpPost("CreateAdvertisement")]
        public async Task<IActionResult> CreateAdvertisement([FromForm] CreateAdvertisementDtos createAdvertisementDtos)
        {
            var advertisement = await _advertisementService.CreateAdvertisement(/*User,*/ createAdvertisementDtos);
            return Ok(createAdvertisementDtos);
        }
    }
}
