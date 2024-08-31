namespace Sigma.UnitTest.Infrastructure;

using Xunit;

using Sigma.Infrastructure;
using Sigma.Infrastructure.Repositories;
using Sigma.Infrastructure.Factories;
using FluentAssertions;

public class CandidateRepositoryFactoryTests
{
    [Fact]
    public void CreateShouldReturnCandidateRepositoryWhenCsvTypeIsProvided()
    {
        var csvFilePath = "test.csv";
        var repositoryType = Constants.RepositoryTypes.Csv;
        var factory = new CandidateRepositoryFactory(csvFilePath, repositoryType);

        var repository = factory.Create();

        repository.Should().BeOfType<CandidateRepository>();
    }

    [Fact]
    public void CreateShouldThrowArgumentExceptionWhenUnsupportedTypeIsProvided()
    {
        var csvFilePath = "test.csv";
        var repositoryType = "UnsupportedType";
        var factory = new CandidateRepositoryFactory(csvFilePath, repositoryType);

        Action act = () => factory.Create();

        act.Should().Throw<ArgumentException>()
            .WithMessage($"There is no repository with type '{repositoryType}' allowed types are {Constants.RepositoryTypes.GetRepositoryTypes()}");
    }

    [Fact]
    public void CreateShouldBeCaseInsensitiveForRepositoryType()
    {
        var csvFilePath = "test.csv";
        var repositoryType = Constants.RepositoryTypes.Csv.ToUpper();
        var factory = new CandidateRepositoryFactory(csvFilePath, repositoryType);

        var repository = factory.Create();

        repository.Should().BeOfType<CandidateRepository>();
    }
}