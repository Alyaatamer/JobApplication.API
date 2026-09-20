using JobApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.JobCandidateApplications.Queries.GetJobCandidateApplicationById
{
    public class GetJobCandidateApplicationByIdQuery : IRequest<JobCandidateApplication?>
    {
        public int Id { get; set; }
    }
}
