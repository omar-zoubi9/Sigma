namespace Sigma.Application.Command.Candidate;

using MediatR;

using Sigma.Domain.DataModels.Candidate;

public sealed class CandidateCommand : IRequest<BaseResponse<int>>, ICandidateModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime CallDate { get; set; }

    public string LinkedInProfileURL { get; set; }

    public string GitHubProfileURL { get; set; }

    public string Comments { get; set; }
}