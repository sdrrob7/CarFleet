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
using DataAccess;
using System.Linq.Expressions;

namespace BusinessLayer.Services
{
    public class MakeService : IMakeService
    {
        private readonly IMakeRepository _repository;
        private IMapper Mapper { get; }
        public MakeService(IMapper mapper, IMakeRepository repository)
        {
            Mapper = mapper;
            _repository = repository;
        }
        public async Task DeleteAsync(int Id)
        {
            await _repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<CarMake>> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();
            return Mapper.Map<IEnumerable<CarMake>>(response);
        }

        public async Task<CarMake> GetByIdAsync(int Id)
        {
            var response = await _repository.GetByIdAsync(Id);
            return Mapper.Map<CarMake>(response);
        }

        public async Task InsertAsync(CarMake model)
        {
            await _repository.InsertAsync(Mapper.Map<MakeTbl>(model));
        }

        public async Task UpdateAsync(CarMake model)
        {
            await _repository.UpdateAsync(Mapper.Map<MakeTbl>(model));
        }

        public async Task<CarMake> GetByNameAsync(string name)
        {
            var response = await _repository.GetByNameAsync(name);
            return Mapper.Map<CarMake>(response);
        }
    }
}
