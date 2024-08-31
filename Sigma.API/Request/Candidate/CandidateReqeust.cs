namespace Sigma.API.Request.Candidate;

public class CandidateReqeust
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string PhoneNumber { get; private set; }

    public DateTime CallDate { get; private set; }

    public string LinkedInProfileURL { get; private set; }

    public string GitHubProfileURL { get; private set; }

    public string Comments { get; private set; }
}