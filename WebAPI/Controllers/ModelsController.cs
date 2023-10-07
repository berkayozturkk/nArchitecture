using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GeList;
using Core.Application.Request;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery()
            {
                PageRequest = pageRequest
            };

            GetListResponse<GetListModelListItemDto> response
                = await Mediator.Send(getListModelQuery);

            return Ok(response);
        }
    }
}
