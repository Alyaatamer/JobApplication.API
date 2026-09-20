using JobApplication.Application.DTOs;
using JobApplication.Domain.Entities;

namespace JobApplication.Application.Interfaces
{
    public interface IJobService
    {
        Task<int> CreateAsync(CreateJobDto createJobDto, string? recruiterId = null);
        IEnumerable<Job> GetAll();
        Job? GetById(int id);
        Task CloseAsync(int id, string recruiterId);
    }
}
