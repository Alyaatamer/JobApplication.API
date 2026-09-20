using JobApplication.Application.DTOs;
using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Features.Jobs.Commands.CreateJob
{
    public class CreateJobHandler : IRequestHandler<CreateJobCommand, int>
    {
        private readonly IRepository<Job> _jobRepository;

        public CreateJobHandler(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job()
            {
                Title = request.Title,
                Description = request.Description,
                IsActive = true
            };
            await _jobRepository.AddAsync(job);
            await _jobRepository.SaveChangesAsync();
            return job.Id;
        }
    }
}
