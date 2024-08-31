namespace Sigma.Application.Validations.Candidate;

using FluentValidation;

using Sigma.Application.Command.Candidate;

public class CandidateValidator : AbstractValidator<CandidateCommand>
{
    public CandidateValidator()
    {
        RuleFor(x => x.FirstName)
           .NotEmpty()
           .WithMessage("First name is required.")
           .Length(1, 50)
           .WithMessage("First name must be between 1 and 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .Length(1, 50)
            .WithMessage("Last name must be between 1 and 50 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Phone number is not valid.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(x => x.CallDate)
            .NotEmpty()
            .WithMessage("Call date is required.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Call date cannot be in the future.");

        RuleFor(x => x.LinkedInProfileURL)
                    .Matches(@"^(https?:\/\/)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}\/?.*$")
                    .When(x => !string.IsNullOrEmpty(x.LinkedInProfileURL))
                    .WithMessage("LinkedIn profile URL is not valid.");

        RuleFor(x => x.GitHubProfileURL)
            .Matches(@"^(https?:\/\/)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}\/?.*$")
            .When(x => !string.IsNullOrEmpty(x.GitHubProfileURL))
            .WithMessage("GitHub profile URL is not valid.");

        RuleFor(x => x.Comments)
            .MaximumLength(500)
            .WithMessage("Comments cannot be more than 500 characters.");
    }
}