using JobApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.Jobs.Queries.GetJobById
{
    public class GetJobByIdQuery : IRequest<Job?>
    {
        public int Id { get; set; }
    }
}
