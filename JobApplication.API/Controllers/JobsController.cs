using JobApplication.Application.DTOs;
using JobApplication.Application.Features.Jobs.Commands.CreateJob;
using JobApplication.Application.Features.Jobs.Queries.GetAllJobs;
using JobApplication.Application.Features.Jobs.Queries.GetJobById;
using JobApplication.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        //private readonly IJobService _JobService;
        private readonly IMediator _mediator;

        public JobsController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var jobs = _JobService.GetAll();
            var jobs = _mediator.Send(new GetAllJobsQuery()); 
            return Ok(new { jobs });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var job = _JobService.GetById(id);
            var job = _mediator.Send(new GetJobByIdQuery() { Id = id}); 
            if (job is null) return NotFound(new
            {
                message = "invalid Id"
            });
            return Ok(new { job });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobDto createJobDto)
        {
            //var id = await _JobService.CreateAsync(createJobDto);
            var id = await _mediator.Send(new CreateJobCommand() { Title = createJobDto.Title  , Description = createJobDto.Description }); 

            return Ok(new
            {
                id = id
            });
        }
    }
}
