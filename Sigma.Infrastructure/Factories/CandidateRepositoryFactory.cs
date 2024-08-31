namespace Sigma.Infrastructure.Factories;

using Sigma.Domain.AggregateModels.CandidateAggregate;

using Sigma.Infrastructure.Repositories;

public class CandidateRepositoryFactory : ICandidateRepositoryFactory
{
    private readonly string _csvFilePath;
    private readonly string _repositoryType;

    public CandidateRepositoryFactory(string csvFilePath, string repositoryType)
    {
        _csvFilePath = csvFilePath;
        _repositoryType = repositoryType;
    }

    public ICandidateRepository Create()
    {
        if (_repositoryType.Equals(Constants.RepositoryTypes.Csv, StringComparison.OrdinalIgnoreCase))
        {
            return new CandidateRepository(_csvFilePath);
        }

        throw new ArgumentException($"There is no repository with type '{_repositoryType}' allowed types are {Constants.RepositoryTypes.GetRepositoryTypes()}");
    }
}