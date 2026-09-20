using JobApplication.Application.DTOs;
using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplication.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository<Job> _jobRepository;

        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<int> CreateAsync(CreateJobDto createJobDto, string? recruiterId = null)
        {   
            var job = new Job()
            {
                Title = createJobDto.Title,
                Description = createJobDto.Description,
                IsActive = true,
                RecruiterId = recruiterId
            };
            await _jobRepository.AddAsync(job);
            await _jobRepository.SaveChangesAsync();

            return job.Id;
        }

        public IEnumerable<Job> GetAll()
        {
            var jobs = _jobRepository.Get().ToList();
            return jobs;
        }

        public Job? GetById(int id)
        {
            var job = _jobRepository.Get().FirstOrDefault(j => j.Id == id);
            return job;
        }

        public async Task CloseAsync(int id, string recruiterId)
        {
            var job = _jobRepository.Get().FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                throw new KeyNotFoundException($"Job with id {id} was not found.");
            }

            job.Close(recruiterId);
            _jobRepository.Update(job);
            await _jobRepository.SaveChangesAsync();
        }
    }
}
