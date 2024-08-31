namespace Sigma.Application.Command.Candidate;

using MediatR;

using Sigma.Domain.AggregateModels.CandidateAggregate;

public sealed class CandidateCommandHandler : IRequestHandler<CandidateCommand, BaseResponse<Candidate>>
{
    private readonly ICandidateRepositoryFactory _candidateRepositoryFactory;

    public CandidateCommandHandler(ICandidateRepositoryFactory candidateRepositoryFactory)
    {
        _candidateRepositoryFactory = candidateRepositoryFactory;
    }

    public async Task<BaseResponse<Candidate>> Handle(CandidateCommand request, CancellationToken cancellationToken)
    {
        var candidateRepository = _candidateRepositoryFactory.Create();

        var candidate = await candidateRepository.GetCandidateByEmailAsync(request.Email);

        if (candidate is null)
        {
            var newCandidate = Candidate.New(request);

            await candidateRepository.AddCandidateAsync(newCandidate);

            return new BaseResponse<Candidate>() { Data = newCandidate, IsSuccess = true };
        }
        else
        {
            candidate.Update(request);

            await candidateRepository.UpdateCandidateAsync(candidate);

            return new BaseResponse<Candidate>() { Data = candidate, IsSuccess = true };
        }
    }
}