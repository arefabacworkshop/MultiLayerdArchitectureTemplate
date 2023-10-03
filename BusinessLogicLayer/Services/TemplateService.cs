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
        public async Task<TemplateDTO> AddTemplate(TemplateDTO templateDto)
        {
            var template = _mapper.Map<Template>(templateDto);
            template.uid = Guid.NewGuid();
            await _templateRepository.AddTemplateAsync(template);
            return _mapper.Map<TemplateDTO>(template);
        }
        public async Task<TemplateDTO> DeleteTemplate(Guid uid)
        {
            var template = await _templateRepository.GetTemplateByIdAsync(uid);
            if (template == null) return null;
            await _templateRepository.DeleteTemplateAsync(template);
            return _mapper.Map<TemplateDTO>(template);
        }
        public async Task<TemplateDTO> GetTemplateById (Guid uid)
        {
            return _mapper.Map<TemplateDTO>(await _templateRepository.GetTemplateByIdAsync(uid));
        }
        public async Task<TemplateDTO> UpdateTemplate(TemplateDTO templateDto)
        {
            var target = await _templateRepository.GetTemplateByIdAsync(templateDto.uid);
            _mapper.Map(templateDto , target);
            await _templateRepository.UpdateTemplateAsync(target);
            return _mapper.Map<TemplateDTO>(target);
        }
        public async Task<IEnumerable<TemplateDTO>> GetAllTemplate()
        {
            var templates = await _templateRepository.GetAllTemplateAsync();
            return _mapper.Map<IEnumerable<TemplateDTO>>(templates);
        }
    }
}
