using JobApplication.Application.DTOs;
using JobApplication.Application.Features.JobCandidateApplications.Commands.CreateJobCandidateApplication;
using JobApplication.Application.Features.JobCandidateApplications.Commands.UpdateJobCandidateApplicationStatus;
using JobApplication.Application.Features.JobCandidateApplications.Queries.GetAllJobCandidateApplications;
using JobApplication.Application.Features.JobCandidateApplications.Queries.GetJobCandidateApplicationById;
using JobApplication.Application.Interfaces;
using JobApplication.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobCandidateApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications = await _mediator.Send(new GetAllJobCandidateApplicationsQuery());
            return Ok(new { applications });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application = await _mediator.Send(new GetJobCandidateApplicationByIdQuery() { Id = id });
            if (application is null) return NotFound(new
            {
                message = "invalid Id"
            });
            return Ok(new { application });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobCandidateApplicationDto createApplicationDto)
        {
            var id = await _mediator.Send(new CreateJobCandidateApplicationCommand() { JobId = createApplicationDto.JobId, CandidateId = createApplicationDto.CandidateId });
            return Ok(new { id = id });
        }

        [HttpPatch("{id}/{status}")]
        public async Task<IActionResult> Update(int id, JobApplicationStatus status)
        {
            var job = await _mediator.Send(new UpdateJobCandidateApplicationStatusCommand() { Id = id, Status = status });
            if (job == null) return NotFound();
            return Ok(new { id = job.Id });
        }
    }
}
