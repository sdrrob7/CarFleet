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
    public class CarRepository : ICarRepository
    {
        private readonly CarFleetContext _context;
        public CarRepository(CarFleetContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int Id)
        {
            var data = await _context.CarTbls.FirstOrDefaultAsync(x => x.Id == Id);
            if (data != null)
            {
                _context.CarTbls.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CarTbl>> GetAllAsync()
        {
            var response = await _context.CarTbls.Select(x => new CarTbl
            {
                Id = x.Id,
                Year = x.Year,
                Transmission = x.Transmission,
                CreatedDate = x.CreatedDate,
                Make = x.Make,
                Model = x.Model,
                Color = x.Color
            }).ToListAsync();
            return response;
        }

        public async Task<IEnumerable<CarTbl>> GetAllCarsByMakeId(int MakeId)
        {
            var response = await _context.CarTbls.Where(x => x.MakeId == MakeId).Select(x => new CarTbl
            {
                Id = x.Id,
                Year = x.Year,
                Transmission = x.Transmission,
                CreatedDate = x.CreatedDate,
                Make = x.Make,
                Model = x.Model,
                Color = x.Color

            }).ToListAsync();
            return response;
        }

        public async Task<IEnumerable<CarTbl>> GetAllCarsByMakeName(string MakeName)
        {
            var response = await _context.CarTbls.Where(x => x.Make.Name == MakeName).Select(x => new CarTbl
            {
                Id = x.Id,
                Year = x.Year,
                Transmission = x.Transmission,
                CreatedDate = x.CreatedDate,
                Make = x.Make,
                Model = x.Model,
                Color = x.Color
            }).ToListAsync();
            return response;
        }

        public async Task<CarTbl> GetByIdAsync(int Id)
        {
            var response = await _context.CarTbls.Where(x => x.Id == Id).Select(x => new CarTbl
            {
                Id = x.Id,
                Year = x.Year,
                Transmission = x.Transmission,
                CreatedDate = x.CreatedDate,
                Make = x.Make,
                Model = x.Model,
                Color = x.Color
            }).FirstOrDefaultAsync();
            return response;
        }

        public async Task InsertAsync(CarTbl entity)
        {
            _context.CarTbls.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CarTbl entity)
        {
            var data = await _context.CarTbls.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (data != null)
            {
                data.MakeId = entity.MakeId;
                data.ModelId = entity.ModelId;
                data.ColorId = entity.ColorId;
                data.Year = entity.Year;
                data.Transmission = entity.Transmission;
                await _context.SaveChangesAsync();
            }
        }
    }
}
