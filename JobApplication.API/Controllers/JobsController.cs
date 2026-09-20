using JobApplication.Application.DTOs;
using JobApplication.Application.Features.Jobs.Commands.CloseJob;
using JobApplication.Application.Features.Jobs.Commands.CreateJob;
using JobApplication.Application.Features.Jobs.Queries.GetAllJobs;
using JobApplication.Application.Features.Jobs.Queries.GetJobById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _mediator.Send(new GetAllJobsQuery()); 
            return Ok(new { jobs });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _mediator.Send(new GetJobByIdQuery() { Id = id }); 
            if (job is null) return NotFound(new
            {
                message = "invalid Id"
            });
            return Ok(new { job });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobDto createJobDto)
        {
            var recruiterId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = await _mediator.Send(new CreateJobCommand() 
            { 
                Title = createJobDto.Title, 
                Description = createJobDto.Description,
                RecruiterId = recruiterId
            }); 

            return Ok(new
            {
                id = id
            });
        }

        [Authorize]
        [HttpPut("{id}/close")]
        public async Task<IActionResult> Close(int id)
        {
            var recruiterId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(recruiterId))
            {
                return Unauthorized(new { message = "User is not authenticated." });
            }

            try
            {
                await _mediator.Send(new CloseJobCommand { Id = id, RecruiterId = recruiterId });
                return Ok(new { message = "Job closed successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
