namespace Sigma.Domain.AggregateModels.CandidateAggregate;

public interface ICandidateRepositoryFactory
{
    ICandidateRepository Create();
}