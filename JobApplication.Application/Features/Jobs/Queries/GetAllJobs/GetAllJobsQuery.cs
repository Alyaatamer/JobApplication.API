using JobApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.Jobs.Queries.GetAllJobs
{
    public class GetAllJobsQuery : IRequest<IEnumerable<Job>>
    {
    }
}
