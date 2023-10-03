using BusinessLogicLayer.DTOs;
using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITemplateService
    {
        public Task<IEnumerable<TemplateDTO>> GetAllTemplate();
        public Task<TemplateDTO> GetTemplateById(Guid uid);
        public Task<TemplateDTO> DeleteTemplate(Guid uid);
        public Task<TemplateDTO> UpdateTemplate(TemplateDTO template);
        public Task<TemplateDTO> AddTemplate(TemplateDTO template);
    }
}
