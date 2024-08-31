namespace Sigma.API.MappingProfiles;

using AutoMapper;

using Sigma.API.Request.Candidate;
using Sigma.Application.Command.Candidate;

public class CandidateProfile : Profile
{
    public CandidateProfile()
    {
        CreateMap<CandidateReqeust, CandidateCommand>();
    }
}