namespace Sigma.Domain.AggregateModels.CandidateAggregate;

public interface ICandidateRepository
{
    Task<Candidate> GetCandidateAsync(string email);

    Task AddCandidateAsync(Candidate candidate);

    Task UpdateCandidateAsync(Candidate candidate);
}