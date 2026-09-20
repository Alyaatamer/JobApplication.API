using JobApplication.Application.DTOs;
using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using JobApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Application.Services
{
    public class JobCandidateApplicationService : IJobCandidateApplicationService
    {
        private readonly IRepository<JobCandidateApplication> _jobApplicationRepository;

        public JobCandidateApplicationService(IRepository<JobCandidateApplication> jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }
        public IEnumerable<JobCandidateApplication> GetAll()
        {
            var applications = _jobApplicationRepository.Get().ToList();
            return applications;
        }
        public async Task<int> CreateAsync(CreateJobCandidateApplicationDto createJobApplicationDto)
        {
            var jobApplication = new JobCandidateApplication()
            {
                JobId = createJobApplicationDto.JobId,
                CandidateId = createJobApplicationDto.CandidateId,
            };
            await _jobApplicationRepository.AddAsync(jobApplication);
            await _jobApplicationRepository.SaveChangesAsync();
            return jobApplication.Id;
        }
        public async Task<JobCandidateApplication?> UpdateStatus(int id, JobApplicationStatus status)
        {
            var jobApplication = _jobApplicationRepository.Get().FirstOrDefault(a => a.Id == id);
            if (jobApplication == null)
            {
                return null;
            }
            jobApplication.UpdateStatus(status);
            await _jobApplicationRepository.SaveChangesAsync();
            return jobApplication;
        }
    }
}
