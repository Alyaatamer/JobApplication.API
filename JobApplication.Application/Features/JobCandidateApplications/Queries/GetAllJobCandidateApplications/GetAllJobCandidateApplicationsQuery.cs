using JobApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.JobCandidateApplications.Queries.GetAllJobCandidateApplications
{
    public class GetAllJobCandidateApplicationsQuery : IRequest<IEnumerable<JobCandidateApplication>>
    {
    }
}
