namespace Sigma.UnitTest.Builders.Candidate;

using Sigma.Domain.AggregateModels.CandidateAggregate;

public class CandidateBuilder
{
    private readonly Candidate _candidate;

    public CandidateBuilder()
    {
        var candidateCommand = new CandidateCommandBuilder()
            .WithTestValues()
            .Build();

        _candidate = Candidate.New(candidateCommand);
    }

    public Candidate Build()
    {
        return _candidate;
    }

    public CandidateBuilder WithTestValues()
    {
        _candidate.FirstName = "Test";
        _candidate.LastName = "Test";
        _candidate.Email = "Test@gmail.com";
        _candidate.PhoneNumber = "12345";
        _candidate.Comments = "";
        _candidate.GitHubProfileURL = "";
        _candidate.LinkedInProfileURL = "";

        return this;
    }

    public CandidateBuilder WithEmptyFirstName()
    {
        _candidate.FirstName = string.Empty;

        return this;
    }

    public CandidateBuilder WithEmptyLastName()
    {
        _candidate.LastName = string.Empty;

        return this;
    }

    public CandidateBuilder WithEmptyEmail()
    {
        _candidate.Email = string.Empty;

        return this;
    }

    public CandidateBuilder WithEmptyPhoneNumber()
    {
        _candidate.PhoneNumber = string.Empty;

        return this;
    }

    public CandidateBuilder WithEmptyComments()
    {
        _candidate.Comments = string.Empty;

        return this;
    }

    public CandidateBuilder WithEmptyLinkedInProfileURL()
    {
        _candidate.LinkedInProfileURL = string.Empty;

        return this;
    }

    public CandidateBuilder WithEmptyGitHubProfileURL()
    {
        _candidate.GitHubProfileURL = string.Empty;

        return this;
    }
}