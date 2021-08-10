using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bamboo.Api.Extensions;
using Bamboo.Application.Features.Account.ViewModel;

namespace Bamboo.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly RestClient<Account, string> _restClient;
        private readonly string baseAddress = "https://api-stage.bamboocardportal.com/api/integration/v1.0/";

        public AccountController()
        {
            _restClient = new RestClient<Account, string>(baseAddress, "accounts");
        }


        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var response = await _restClient.GetAsync("");
            return Ok(response);
        }

    }
}
