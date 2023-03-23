using System;
using API.Application.Commands.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using API.Application.ViewModels;
using Domain.Exceptions;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            try
            {
                var order = await _mediator.Send(command);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("ConfirmOrder")]
        public async Task<IActionResult> ConfirmOrder([FromBody] ConfirmOrderCommand command)
        {
            try
            {
                var order = await _mediator.Send(command);
                if (order == null)
                {
                    return BadRequest("Invalid Order Id");
                }

                return Ok();
            }
            catch (OrderDomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
