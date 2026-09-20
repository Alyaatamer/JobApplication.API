using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.JobCandidateApplications.Commands.CreateJobCandidateApplication
{
    public class CreateJobCandidateApplicationCommand : IRequest<int>
    {
        public int JobId { get; set; }
        public int CandidateId { get; set; }
    }
}
