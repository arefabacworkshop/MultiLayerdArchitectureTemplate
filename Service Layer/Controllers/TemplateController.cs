using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations.Rules;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Service_Layer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private ITemplateService _templateService;
        public TemplateController(ITemplateService tempService)
        {
            _templateService = tempService;
        }
        [HttpGet("{uid?}")]
        public async Task<IActionResult> get(Guid? uid)
        {
            if(uid == null)
            return Ok(await _templateService.GetAllTemplate());
            else return Ok(await _templateService.GetTemplateById((Guid)uid));
        }
        [HttpDelete("{uid?}")]
        public async Task<IActionResult> delete(Guid? uid)
        {
            if (uid == null) return BadRequest("no id");
            return Ok(await _templateService.DeleteTemplate((Guid)uid));
        }
        [HttpPut]
        public async Task<IActionResult> update([FromBody]TemplateDTO model)
        {
            var result = await _templateService.UpdateTemplate(model);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]TemplateDTO model)
        {
            var result = await _templateService.AddTemplate(model);
            return Ok(result);
        }
    }
}
