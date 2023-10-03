using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private IRepository<Template> _repo;
        public TemplateRepository(IRepository<Template> repo)
        {
            _repo = repo;
        }
        public async Task AddTemplateAsync(Template entity)
        {

             await _repo.AddAsync(entity);
        }

        public async Task DeleteTemplateAsync(Template entity)
        {
            await _repo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Template>> GetAllTemplateAsync()
        {
           return await _repo.GetAllAsync();
        }

        public async Task<Template> GetTemplateByIdAsync(Guid uid)
        {
            return await _repo.GetByIdAsync(uid);
        }

        public async Task UpdateTemplateAsync(Template entity)
        {
            await _repo.UpdateAsync(entity);
        }
    }
}
