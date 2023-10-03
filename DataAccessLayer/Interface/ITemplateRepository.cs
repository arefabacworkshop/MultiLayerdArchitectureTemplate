using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ITemplateRepository
    {
        Task<Template> GetTemplateByIdAsync(Guid id);
        Task<IEnumerable<Template>> GetAllTemplateAsync();
        Task AddTemplateAsync(Template entity);
        Task UpdateTemplateAsync(Template entity);
        Task DeleteTemplateAsync(Template entity);

    }
}
