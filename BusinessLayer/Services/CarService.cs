using AutoMapper;
using BusinessLayer.Contacts;
using DataAccess.Contacts;
using DataAccess.Entities;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private IMapper Mapper { get; }
        public CarService(IMapper mapper, ICarRepository repository)
        {
            Mapper = mapper;
            _repository = repository;
        }
        public async Task DeleteAsync(int Id)
        {
            await _repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<CarViewModel>> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();
            return Mapper.Map<IEnumerable<CarViewModel>>(response);
        }

        public async Task<CarViewModel> GetByIdAsync(int Id)
        {
            var response = await _repository.GetByIdAsync(Id);
            return Mapper.Map<CarViewModel>(response);
        }

        public async Task InsertAsync(CarModelBind model)
        {
            await _repository.InsertAsync(Mapper.Map<CarTbl>(model));
        }

        public async Task UpdateAsync(CarModelBind model)
        {
            await _repository.UpdateAsync(Mapper.Map<CarTbl>(model));
        }

        public async Task<IEnumerable<CarViewModel>> GetAllCarsByMakeId(int MakeId)
        {
            var response = await _repository.GetAllCarsByMakeId(MakeId);
            return Mapper.Map<IEnumerable<CarViewModel>>(response);
        }

        public async Task<IEnumerable<CarViewModel>> GetAllCarsByMakeName(string MakeName)
        {
            var response = await _repository.GetAllCarsByMakeName(MakeName);
            return Mapper.Map<IEnumerable<CarViewModel>>(response);
        }
    }
}
