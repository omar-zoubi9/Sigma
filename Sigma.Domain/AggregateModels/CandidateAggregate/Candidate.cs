namespace Sigma.Domain.AggregateModels.CandidateAggregate;

public class Candidate : BaseEntity<Guid>
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string PhoneNumber { get; private set; }

    public DateTime CallDate { get; private set; }

    public string LinkedInProfileURL { get; private set; }

    public string GitHubProfileURL { get; private set; }

    public string Comments { get; private set; }
}