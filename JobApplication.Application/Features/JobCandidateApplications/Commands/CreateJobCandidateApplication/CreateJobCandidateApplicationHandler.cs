using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.JobCandidateApplications.Commands.CreateJobCandidateApplication
{
    public class CreateJobCandidateApplicationHandler : IRequestHandler<CreateJobCandidateApplicationCommand, int>
    {
        private readonly IRepository<JobCandidateApplication> _jobApplicationRepository;

        public CreateJobCandidateApplicationHandler(IRepository<JobCandidateApplication> jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<int> Handle(CreateJobCandidateApplicationCommand request, CancellationToken cancellationToken)
        {
            var jobApplication = new JobCandidateApplication()
            {
                JobId = request.JobId,
                CandidateId = request.CandidateId,
            };
            await _jobApplicationRepository.AddAsync(jobApplication);
            await _jobApplicationRepository.SaveChangesAsync();
            return jobApplication.Id;
        }
    }
}
