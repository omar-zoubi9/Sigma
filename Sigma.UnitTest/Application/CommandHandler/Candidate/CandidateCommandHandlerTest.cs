namespace Sigma.UnitTest.Application.CommandHandler.Candidate;

using FluentAssertions;

using MediatR;

using Moq;

using Sigma.Application;
using Sigma.Application.Command.Candidate;
using Sigma.Domain.AggregateModels.CandidateAggregate;
using Sigma.UnitTest.Builders.Candidate;
using Sigma.UnitTest.Services;

using Xunit;

public class CandidateCommandHandlerTest : ApplicationServiceTestsBase
{
    private readonly IRequestHandler<CandidateCommand, BaseResponse<Candidate>> _requestHandler;

    private readonly Mock<ICandidateRepository> mockCandidateRepository = new Mock<ICandidateRepository>(MockBehavior.Strict);
    private readonly Mock<ICandidateRepositoryFactory> mockCandidateRepositoryFactory = new Mock<ICandidateRepositoryFactory>(MockBehavior.Strict);

    public CandidateCommandHandlerTest()
    {
        _requestHandler = new CandidateCommandHandler(mockCandidateRepositoryFactory.Object);
    }

    [Fact]
    public async Task CreateCandidateShouldReturnSucssesCode()
    {
        var candidateCommand = new CandidateCommandBuilder()
            .WithTestValues()
            .Build();

        var candidate = new CandidateBuilder()
            .WithTestValues()
            .Build();

        mockCandidateRepositoryFactory.Setup(candidateRepositoryFactory => candidateRepositoryFactory.Create())
            .Returns(mockCandidateRepository.Object);

        mockCandidateRepository.Setup(candidateRepository => candidateRepository.GetCandidateByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((Candidate)null);

        mockCandidateRepository.Setup(candidateRepository => candidateRepository.AddCandidateAsync(It.IsAny<Candidate>()))
            .Returns(Task.FromResult(candidate));

        var result = await _requestHandler.Handle(candidateCommand, CancellationToken.None).ConfigureAwait(false);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task UpdateCandidateShouldReturnSucssesCode()
    {
        var candidateCommand = new CandidateCommandBuilder()
            .WithTestValues()
            .Build();

        var candidate = new CandidateBuilder()
            .WithTestValues()
            .Build();

        mockCandidateRepositoryFactory.Setup(candidateRepositoryFactory => candidateRepositoryFactory.Create())
            .Returns(mockCandidateRepository.Object);

        mockCandidateRepository.Setup(candidateRepository => candidateRepository.GetCandidateByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(candidate);

        mockCandidateRepository.Setup(candidateRepository => candidateRepository.UpdateCandidateAsync(It.IsAny<Candidate>()))
            .Returns(Task.FromResult(candidate));

        var result = await _requestHandler.Handle(candidateCommand, CancellationToken.None).ConfigureAwait(false);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
    }
}