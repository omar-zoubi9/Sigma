using Sigma.Domain.DataModels.Candidate;

namespace Sigma.Domain.AggregateModels.CandidateAggregate;

public class Candidate : BaseEntity<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public DateTime CallDate { get; set; }

    public string LinkedInProfileURL { get; set; }

    public string GitHubProfileURL { get; set; }

    public string Comments { get; set; }

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