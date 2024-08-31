namespace Sigma.UnitTest.Builders.Candidate;

using Sigma.Application.Command.Candidate;

public class CandidateCommandBuilder
{
    private readonly CandidateCommand _candidateCommand;

    public CandidateCommandBuilder()
    {
        _candidateCommand = new CandidateCommand();
    }

    public CandidateCommand Build()
    {
        return _candidateCommand;
    }

    public CandidateCommandBuilder WithTestValues()
    {
        _candidateCommand.FirstName = "Test";
        _candidateCommand.LastName = "Test";
        _candidateCommand.Email = "Test@gmail.com";
        _candidateCommand.PhoneNumber = "12345";
        _candidateCommand.Comments = "";
        _candidateCommand.GitHubProfileURL = "";
        _candidateCommand.LinkedInProfileURL = "";

        return this;
    }

    public CandidateCommandBuilder WithEmptyFirstName()
    {
        _candidateCommand.FirstName = string.Empty;

        return this;
    }

    public CandidateCommandBuilder WithEmptyLastName()
    {
        _candidateCommand.LastName = string.Empty;

        return this;
    }

    public CandidateCommandBuilder WithEmptyEmail()
    {
        _candidateCommand.Email = string.Empty;

        return this;
    }

    public CandidateCommandBuilder WithEmptyPhoneNumber()
    {
        _candidateCommand.PhoneNumber = string.Empty;

        return this;
    }

    public CandidateCommandBuilder WithEmptyComments()
    {
        _candidateCommand.Comments = string.Empty;

        return this;
    }

    public CandidateCommandBuilder WithEmptyLinkedInProfileURL()
    {
        _candidateCommand.LinkedInProfileURL = string.Empty;

        return this;
    }

    public CandidateCommandBuilder WithEmptyGitHubProfileURL()
    {
        _candidateCommand.GitHubProfileURL = string.Empty;

        return this;
    }
}