using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplication.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string? RecruiterId { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string? ClosedBy { get; set; }

        public void Close(string recruiterId)
        {
            if (RecruiterId != recruiterId)
            {
                throw new UnauthorizedAccessException("Only the owning recruiter can close this job.");
            }

            if (!IsActive)
            {
                throw new InvalidOperationException("Job is already closed.");
            }

            IsActive = false;
            ClosedAt = DateTime.UtcNow;
            ClosedBy = recruiterId;
        }
    }
}
