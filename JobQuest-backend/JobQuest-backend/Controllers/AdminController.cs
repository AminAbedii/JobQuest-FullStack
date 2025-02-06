using JobQuest.Core.DTOs;
using JobQuest.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobQuest_backend.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("ShowAdForAdmin")]
        public async Task<ActionResult<IEnumerable<ShowAdvertisementForAdminDto>>> ShowAdForAdmin()
        {
            var advertisements = await _adminService.ShowAdForAdminAsync();
            return Ok(advertisements);
        }
    }
}
