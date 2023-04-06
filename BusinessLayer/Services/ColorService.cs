using AutoMapper;
using BusinessLayer.Contacts;
using SharedModel;
using DataAccess.Contacts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _repository;
        private IMapper Mapper { get; }
        public ColorService(IMapper mapper, IColorRepository repository)
        {
            Mapper = mapper;
            _repository = repository;
        }
        public async Task DeleteAsync(int Id)
        {
            await _repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<CarColor>> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();
            return Mapper.Map<IEnumerable<CarColor>>(response);
        }

        public async Task<CarColor> GetByIdAsync(int Id)
        {
            var response = await _repository.GetByIdAsync(Id);
            return Mapper.Map<CarColor>(response);
        }

        public async Task InsertAsync(CarColor model)
        {
            await _repository.InsertAsync(Mapper.Map<ColorTbl>(model));
        }

        public async Task UpdateAsync(CarColor model)
        {
            await _repository.UpdateAsync(Mapper.Map<ColorTbl>(model));
        }
    }
}
