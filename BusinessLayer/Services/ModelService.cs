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
    public class ModelService : IModelService
    {
        private readonly IModelRepository _repository;
        private IMapper Mapper { get; }
        public ModelService(IMapper mapper, IModelRepository repository)
        {
            Mapper = mapper;
            _repository = repository;
        }
        public async Task DeleteAsync(int Id)
        {
            await _repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<CarModel>> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();
            return Mapper.Map<IEnumerable<CarModel>>(response);
        }

        public async Task<CarModel> GetByIdAsync(int Id)
        {
            var response = await _repository.GetByIdAsync(Id);
            return Mapper.Map<CarModel>(response);
        }

        public async Task InsertAsync(CarModel model)
        {
            await _repository.InsertAsync(Mapper.Map<ModelTbl>(model));
        }

        public async Task UpdateAsync(CarModel model)
        {
            await _repository.UpdateAsync(Mapper.Map<ModelTbl>(model));
        }
    }
}
