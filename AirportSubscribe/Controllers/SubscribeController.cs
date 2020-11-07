using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportSubscribe.Servers.Urls;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirportSubscribe.Controllers
{
    [Route("api/Subscribe")]
    public class SubscribeController : Controller
    {
        private IMediator _mediator { get; set; }

        public SubscribeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var str = await _mediator.Send(new GetSubscribe.GetSubscribeQuery());
            return Ok(str);
        }
    }
}
