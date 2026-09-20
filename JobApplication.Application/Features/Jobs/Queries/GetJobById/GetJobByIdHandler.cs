using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.Jobs.Queries.GetJobById
{

    internal class GetJobByIdHandler : IRequestHandler<GetJobByIdQuery, Job?>
    {
        private readonly IRepository<Job> _jobRepository;

        public GetJobByIdHandler(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Job?> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.Get().FirstOrDefaultAsync(j => j.Id == request.Id);
            return job;
        }
    }
}
