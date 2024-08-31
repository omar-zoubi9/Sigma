using Sigma.Domain.DataModels.Candidate;

namespace Sigma.Domain.AggregateModels.CandidateAggregate;

public class Candidate : BaseEntity<Guid>
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string PhoneNumber { get; private set; }

    public string Email { get; set; }

    public DateTime CallDate { get; private set; }

    public string LinkedInProfileURL { get; private set; }

    public string GitHubProfileURL { get; private set; }

    public string Comments { get; private set; }

    public static Candidate New(ICandidateModel model)
    {
        var instance = new Candidate
        {
            Id = Guid.NewGuid(),
            FirstName = model.FirstName,
            LastName = model.LastName,
            CallDate = model.CallDate,
            Comments = model.Comments,
            Email = model.Email,
            GitHubProfileURL = model.GitHubProfileURL,
            LinkedInProfileURL = model.LinkedInProfileURL,
            PhoneNumber = model.PhoneNumber
        };

        return instance;
    }

    public void Update(ICandidateModel model)
    {
        FirstName = model.FirstName;
        LastName = model.LastName;
        CallDate = model.CallDate;
        Comments = model.Comments;
        Email = model.Email;
        GitHubProfileURL = model.GitHubProfileURL;
        LinkedInProfileURL = model.LinkedInProfileURL;
        PhoneNumber = model.PhoneNumber;
    }
}