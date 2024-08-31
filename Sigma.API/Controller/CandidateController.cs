namespace Sigma.API.Controller;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Sigma.API.Request.Candidate;
using Sigma.Application.Command.Candidate;

public class CandidateController : BaseController
{
    protected CandidateController(IMediator mediator, IMapper mapper)
        : base(mediator, mapper)
    {
    }

    [HttpPost("create-or-update")]
    public async Task<IActionResult> CreateOrUpdate(CandidateReqeust request)
    {
        var candidateCommand = Mapper.Map<CandidateCommand>(request);

        var response = await Mediator.Send(candidateCommand);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}