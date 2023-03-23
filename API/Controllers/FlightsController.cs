using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlightsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("Search")]
    public Task<IEnumerable<FlightResponse>> GetAvailableFlights([FromQuery]string destination)
    {
        var availableFlights = _mediator.Send(new SearchFlightsQuery
        {
            Destination = destination
        });

        return availableFlights;
    }
}
