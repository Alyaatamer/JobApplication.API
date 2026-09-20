using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
