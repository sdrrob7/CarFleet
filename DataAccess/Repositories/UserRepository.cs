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
    public class UserRepository : IUserRepository
    {
        private readonly CarFleetContext _context;
        public UserRepository(CarFleetContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserTbl>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserTbl> GetByIdAsync(Guid Id)
        {
            var data = await _context.UserTbls.FirstOrDefaultAsync(x => x.Id == Id);
            return data;
        }

        public async Task InsertAsync(UserTbl entity)
        {
            _context.UserTbls.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserTbl entity)
        {
            var data = await _context.UserTbls.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (data != null)
            {
                data.FirstName = entity.FirstName;
                data.LastName = entity.LastName;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> checkUserNamePassword(string UserName, string Password)
        {
            var data = await _context.UserTbls.FirstOrDefaultAsync(x => x.UserName == UserName && x.Password == Password);
            if (data != null)
                return true;
            else return false;
        }
    }
}
