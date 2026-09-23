using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JobApplication.Application.Features.Jobs.Commands.CloseJob
{
    public class CloseJobCommandHandler : IRequestHandler<CloseJobCommand, bool>
    {
        private readonly IRepository<Job> _jobRepository;

        public CloseJobCommandHandler(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<bool> Handle(CloseJobCommand request, CancellationToken cancellationToken)
        {
            var job = _jobRepository.Get().FirstOrDefault(j => j.Id == request.Id);
            if (job == null)
            {
                throw new KeyNotFoundException($"Job with id {request.Id} was not found.");
            }

            job.Close(request.RecruiterId);
            _jobRepository.Update(job);
            await _jobRepository.SaveChangesAsync();

            return true;
        }
    }
}
