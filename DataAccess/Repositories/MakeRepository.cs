using DataAccess.Contacts;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        private readonly CarFleetContext _context;
        public MakeRepository(CarFleetContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int Id)
        {
            var data = await _context.MakeTbls.FirstOrDefaultAsync(x => x.Id == Id);
            if (data != null)
            {
                _context.MakeTbls.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MakeTbl>> GetAllAsync()
        {
            return await _context.MakeTbls.ToListAsync();
        }

        public async Task<MakeTbl> GetByIdAsync(int Id)
        {
            return await _context.MakeTbls.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<MakeTbl> GetByNameAsync(string name)
        {
            var response = await _context.MakeTbls.Where(x => x.Name == name).FirstOrDefaultAsync();
            return response;
        }

        public async Task InsertAsync(MakeTbl entity)
        {
            _context.MakeTbls.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MakeTbl entity)
        {
            var data = await _context.MakeTbls.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (data != null)
            {
                data.Name = entity.Name;
                await _context.SaveChangesAsync();
            }
        }


    }
}
