namespace Sigma.Infrastructure.Repositories;

using Sigma.Domain.AggregateModels.CandidateAggregate;

using System.Threading.Tasks;

public class CandidateRepository : ICandidateRepository
{
    public Task<Candidate> GetCandidateAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task AddCandidateAsync(Candidate candidate)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCandidateAsync(Candidate candidate)
    {
        throw new NotImplementedException();
    }
}