using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Api.Extensions;
using Bamboo.Application.Features.Order.Commands;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Api.Controllers
{
    public class OrderController : BaseApiController
    {
        private RestClient<CreateOrderCommand, string> _restClient;
        readonly IConfiguration _configuration;

        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
            var url = _configuration.GetValue<string>("APIBaseURL");
            _restClient = new RestClient<CreateOrderCommand, string>(url, "orders/checkout");
        }

        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command)
        {
            var result = await _restClient.Post(command);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                command.RequestID = result.Message;
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            return Ok(result.Message);
        }

    }
}
