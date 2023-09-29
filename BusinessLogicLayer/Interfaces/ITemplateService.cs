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
        public Task<IEnumerable<Template>> GetAllTemplate();
        public Task<Template> GetTemplateById(int id);
        public Task<Template> DeleteTemplate(int id);
        public Task<Template> UpdateTemplate(Template template);
        public Task<Template> AddTemplate(TemplateDTO template);
    }
}
