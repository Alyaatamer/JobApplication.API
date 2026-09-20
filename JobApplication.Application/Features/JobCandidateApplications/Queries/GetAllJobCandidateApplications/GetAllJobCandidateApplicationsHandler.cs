using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.JobCandidateApplications.Queries.GetAllJobCandidateApplications
{
    public class GetAllJobCandidateApplicationsHandler : IRequestHandler<GetAllJobCandidateApplicationsQuery, IEnumerable<JobCandidateApplication>>
    {
        private readonly IRepository<JobCandidateApplication> _jobApplicationRepository;

        public GetAllJobCandidateApplicationsHandler(IRepository<JobCandidateApplication> jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<IEnumerable<JobCandidateApplication>> Handle(GetAllJobCandidateApplicationsQuery request, CancellationToken cancellationToken)
        {
            var applications = await _jobApplicationRepository.Get().ToListAsync();
            return applications;
        }
    }
}
