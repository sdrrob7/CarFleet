using DataAccess.Contacts;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly CarFleetContext _context;
        public ModelRepository(CarFleetContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int Id)
        {
            var data = await _context.ModelTbls.FirstOrDefaultAsync(x => x.Id == Id);
            if (data != null)
            {
                _context.ModelTbls.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ModelTbl>> GetAllAsync()
        {
            return await _context.ModelTbls.ToListAsync();
        }

        public async Task<ModelTbl> GetByIdAsync(int Id)
        {
            return await _context.ModelTbls.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(ModelTbl entity)
        {
            _context.ModelTbls.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ModelTbl entity)
        {
            var data = await _context.ModelTbls.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (data != null)
            {
                data.Name = entity.Name;
                data.MakeId = entity.MakeId;
                await _context.SaveChangesAsync();
            }
        }

    }
}
