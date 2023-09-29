using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.MappingProfiles;
using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TemplateService : ITemplateService
    {
        private ITemplateRepository _templateRepository;
        private IMapper _mapper;
        public TemplateService(ITemplateRepository templateRepository)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TemplateMapper>());
            _mapper = new Mapper(config);
            _templateRepository = templateRepository;
        }
        public async Task<Template> AddTemplate(TemplateDTO templateDto)
        {
            var template = _mapper.Map<Template>(templateDto);
            await _templateRepository.AddTemplateAsync(template);
            return template;
        }

        public async Task<Template> DeleteTemplate(int id)
        {
            var template = await _templateRepository.GetTemplateByIdAsync(id);
            await _templateRepository.DeleteTemplateAsync(template);
            return template;
        }

        public async Task<Template> GetTemplateById (int id)
        {
            return await _templateRepository.GetTemplateByIdAsync(id);
        }

        public async Task<Template> UpdateTemplate(Template template)
        {
            await _templateRepository.UpdateTemplateAsync(template);
            return template;
        }

        public async Task<IEnumerable<Template>> GetAllTemplate()
        {
            return await _templateRepository.GetAllTemplateAsync();
        }
    }
}
