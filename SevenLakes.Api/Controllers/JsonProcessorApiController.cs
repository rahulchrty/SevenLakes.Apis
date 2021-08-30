using Microsoft.AspNetCore.Mvc;
using SevenLakes.Interfaces;
using SevenLakes.Models;
using System;
using System.Collections.Generic;

namespace SevenLakes.Api.Controllers
{
    [Route("route")]
    [ApiController]
    public class JsonProcessorApiController : ControllerBase
    {
        private readonly IFlattenJsonContent _flattenJsonContent;
        public JsonProcessorApiController(IFlattenJsonContent flattenJsonContent)
        {
            _flattenJsonContent = flattenJsonContent;
        }
        [HttpPost]
        public ActionResult<IList<FlattenedJsonModel>> FlattenJson([FromBody] List<NestedJsonModel> payload)
        {
            try
            {
                IList<FlattenedJsonModel> flattenedJson = _flattenJsonContent.GetFlattenedJson(payload);
                return Ok(flattenedJson);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
