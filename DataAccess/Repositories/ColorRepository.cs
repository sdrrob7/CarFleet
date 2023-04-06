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
    public class ColorRepository : IColorRepository
    {
        private readonly CarFleetContext _context;
        public ColorRepository(CarFleetContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int Id)
        {
            var data = await _context.ColorTbls.FirstOrDefaultAsync(x => x.Id == Id);
            if (data != null)
            {
                _context.ColorTbls.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ColorTbl>> GetAllAsync()
        {
            return await _context.ColorTbls.ToListAsync();
        }

        public async Task<ColorTbl> GetByIdAsync(int Id)
        {
            return await _context.ColorTbls.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(ColorTbl entity)
        {
            _context.ColorTbls.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ColorTbl entity)
        {
            var data = await _context.ColorTbls.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (data != null)
            {
                data.Name = entity.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
