namespace Sigma.Application.Command.Candidate;

using MediatR;

public sealed class CandidateCommandHandler : IRequestHandler<CandidateCommand, BaseResponse<int>>
{
    public CandidateCommandHandler()
    {
    }

    public Task<BaseResponse<int>> Handle(CandidateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}