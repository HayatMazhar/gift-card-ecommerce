using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Api.Extensions;
using Bamboo.Application.Features.Product.ViewModel;
using Bamboo.Application.JsonModels;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Api.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly RestClient<Catalog, string> _restClient;
        readonly IConfiguration _configuration;
        
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            var url = _configuration.GetValue<string>("APIBaseURL");
            _restClient = new RestClient<Catalog, string>(url, "catalog");

        }
       
        [HttpGet]
        public async Task<IActionResult> Get(string searchText)
        {
            var response = new Catalog();
            var result = await _restClient.GetAsync("");
            
            if (!string.IsNullOrEmpty(searchText) && searchText != "null" && searchText.Length > 2)
            {
                foreach (var item in result.Brands)
                {
                    if ((!string.IsNullOrEmpty(item.name) && item.name.ToLower().Contains(searchText.ToLower())) || (!string.IsNullOrEmpty(item.description) && item.description.ToLower().Contains(searchText.ToLower())))
                    {
                        response.Brands.Add(item);
                    }
                }
            }
            else
            {
                response = result;
            }

            return Ok(response);
        }


    }
}
