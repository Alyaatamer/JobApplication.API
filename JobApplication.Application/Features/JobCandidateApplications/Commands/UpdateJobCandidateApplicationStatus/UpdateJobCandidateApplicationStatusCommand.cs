using JobApplication.Domain.Entities;
using JobApplication.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.JobCandidateApplications.Commands.UpdateJobCandidateApplicationStatus
{
    public class UpdateJobCandidateApplicationStatusCommand : IRequest<JobCandidateApplication?>
    {
        public int Id { get; set; }
        public JobApplicationStatus Status { get; set; }
    }
}
