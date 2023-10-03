﻿using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private ITemplateService _templateService;
        public TemplateController(ITemplateService tempService)
        {
            _templateService = tempService;
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> get (int? id)
        {
            if(id == null)
            return Ok(await _templateService.GetAllTemplate());
            else return Ok(await _templateService.GetTemplateById((int)id));
        }
        [HttpDelete("{id?}")]
        public async Task<IActionResult> delete(int? id)
        {
            if (id == null) return BadRequest("no id");
            return Ok(await _templateService.DeleteTemplate((int)id));
        }
        [HttpPut]
        public async Task<IActionResult> update(Template model)
        {
            var result = await _templateService.UpdateTemplate(model);
            return Ok(result);
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> Add(TemplateDTO model)
        {
            var result = await _templateService.AddTemplate(model);
            return Ok(result);
        }
    }
}
