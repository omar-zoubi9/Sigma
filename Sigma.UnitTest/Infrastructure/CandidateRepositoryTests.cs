using FluentAssertions;

using Sigma.Domain.AggregateModels.CandidateAggregate;
using Sigma.Infrastructure.Repositories;

using Xunit;

namespace Sigma.Infrastructure.Tests
{
    public class CandidateRepositoryTests : IDisposable
    {
        private readonly string _testFilePath;
        private readonly CandidateRepository _repository;

        public CandidateRepositoryTests()
        {
            _testFilePath = Path.GetTempFileName();
            _repository = new CandidateRepository(_testFilePath);
        }

        [Fact]
        public async Task GetCandidateByEmailAsyncShouldReturnNullWhenCandidateNotFound()
        {
            var result = await _repository.GetCandidateByEmailAsync("nonexistent@example.com");

            result.Should().BeNull();
        }

        [Fact]
        public async Task AddCandidateAsyncShouldAddCandidateWhenValid()
        {
            var candidate = new Candidate
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe"
            };

            await _repository.AddCandidateAsync(candidate);
            var result = await _repository.GetCandidateByEmailAsync(candidate.Email);

            result.Should().NotBeNull();
            result.Email.Should().Be(candidate.Email);
            result.FirstName.Should().Be(candidate.FirstName);
            result.LastName.Should().Be(candidate.LastName);
        }

        [Fact]
        public async Task AddCandidateAsyncShouldThrowExceptionWhenEmailExists()
        {
            var candidate1 = new Candidate
            {
                Email = "duplicate@example.com",
                FirstName = "Jane",
                LastName = "Doe"
            };
            var candidate2 = new Candidate
            {
                Email = "duplicate@example.com",
                FirstName = "Jack",
                LastName = "Smith"
            };

            await _repository.AddCandidateAsync(candidate1);

            Func<Task> act = async () => await _repository.AddCandidateAsync(candidate2);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("A candidate with this email already exists.");
        }

        [Fact]
        public async Task UpdateCandidateAsyncShouldUpdateCandidateWhenExists()
        {
            var candidate = new Candidate
            {
                Email = "update@example.com",
                FirstName = "OldFirstName",
                LastName = "OldLastName"
            };

            await _repository.AddCandidateAsync(candidate);

            candidate.FirstName = "NewFirstName";
            candidate.LastName = "NewLastName";
            await _repository.UpdateCandidateAsync(candidate);

            var updatedCandidate = await _repository.GetCandidateByEmailAsync(candidate.Email);

            updatedCandidate.Should().NotBeNull();
            updatedCandidate.FirstName.Should().Be("NewFirstName");
            updatedCandidate.LastName.Should().Be("NewLastName");
        }

        [Fact]
        public async Task UpdateCandidateAsyncShouldThrowExceptionWhenCandidateNotFound()
        {
            var candidate = new Candidate
            {
                Email = "nonexistent@example.com",
                FirstName = "Nonexistent",
                LastName = "User"
            };

            Func<Task> act = async () => await _repository.UpdateCandidateAsync(candidate);

            await act.Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage("Candidate not found.");
        }

        public void Dispose()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}