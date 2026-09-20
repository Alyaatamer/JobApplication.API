using JobApplication.Application.DTOs;
using JobApplication.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _JobService;

        public JobsController(IJobService jobService)
        {
            _JobService = jobService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobDto createJobDto)
        {
            var id = await _JobService.CreateAsync(createJobDto);
            return Ok(new
            {
                id = id 
            }); 
        }
    }
}
