﻿using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GeList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Request;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
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

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody] DynamicQuery? dynamicQuery)
        {
            GetListByDynamicModelQuery getListByDynamicModelQuery = new GetListByDynamicModelQuery()
            {
                PageRequest = pageRequest,DynamicQuery = dynamicQuery
            };

            GetListResponse<GetListByDynamicModelListItemDto> response
                = await Mediator.Send(getListByDynamicModelQuery);

            return Ok(response);
        }
    }
}
