namespace Sigma.API.Request.Candidate;

public class CandidateReqeust
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime CallDate { get; set; }

    public string LinkedInProfileURL { get; set; }

    public string GitHubProfileURL { get; set; }

    public string Comments { get; set; }
}