using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.JobCandidateApplications.Queries.GetJobCandidateApplicationById
{
    internal class GetJobCandidateApplicationByIdHandler : IRequestHandler<GetJobCandidateApplicationByIdQuery, JobCandidateApplication?>
    {
        private readonly IRepository<JobCandidateApplication> _jobApplicationRepository;

        public GetJobCandidateApplicationByIdHandler(IRepository<JobCandidateApplication> jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<JobCandidateApplication?> Handle(GetJobCandidateApplicationByIdQuery request, CancellationToken cancellationToken)
        {
            var application = await _jobApplicationRepository.Get().FirstOrDefaultAsync(a => a.Id == request.Id);
            return application;
        }
    }
}
