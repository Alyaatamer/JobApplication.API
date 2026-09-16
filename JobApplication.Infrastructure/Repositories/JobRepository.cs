using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using JobApplication.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Infrastructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;

        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Job job )
        {
            await _context.Jobs.AddAsync(job);
        }
        public void Update(Job job)
        {
            _context.Jobs.Update(job);
        }
        public IQueryable<Job> Get()
        {
            var jobs = _context.Jobs.AsQueryable();
            return jobs; 
        }
        public void Remove(Job job)
        {
            _context.Jobs.Remove(job);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
