using AmazonWebSearch.Contracts;
using AmazonWebSearch.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AmazonWebSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmazonSearchController : ControllerBase
    {
        private readonly ILogger<AmazonSearchController> _logger;

        public AmazonSearchController(ILogger<AmazonSearchController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "FindPrice")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public async Task<IResult> FindPrice([FromBody]PriceSearchRequest request)
        {

            var _search = new SeleniumSearch();
            var price = await _search.FindPrice(request.ProductCatgoty, request.DeliveryCountry);

            _logger.LogInformation(
                "Found price {0} for product category'{1} and country '{2}",
                price, 
                request.ProductCatgoty, 
                request.DeliveryCountry);

            return Results.Ok(price);
        }
    }
}