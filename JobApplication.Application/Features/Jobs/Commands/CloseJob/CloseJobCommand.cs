using MediatR;

namespace JobApplication.Application.Features.Jobs.Commands.CloseJob
{
    public class CloseJobCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string RecruiterId { get; set; } = string.Empty;
    }
}
