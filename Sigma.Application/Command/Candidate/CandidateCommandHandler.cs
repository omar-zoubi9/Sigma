namespace Sigma.Application.Command.Candidate;

using MediatR;

using Sigma.Domain.AggregateModels.CandidateAggregate;

public sealed class CandidateCommandHandler : IRequestHandler<CandidateCommand, BaseResponse<Candidate>>
{
    private readonly ICandidateRepository _candidateRepository;

    public CandidateCommandHandler(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }

    public async Task<BaseResponse<Candidate>> Handle(CandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = await _candidateRepository.GetCandidateAsync(request.Email);

        if (candidate is null)
        {
            var newCandidate = Candidate.New(request);

            await _candidateRepository.AddCandidateAsync(newCandidate);
        }
        else
        {
            candidate.Update(request);

            await _candidateRepository.UpdateCandidateAsync(candidate);
        }

        return new BaseResponse<Candidate>() { Data = candidate, IsSuccess = true };
    }
}