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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private IMapper Mapper { get; }
        public UserService(IMapper mapper, IUserRepository repository)
        {
            Mapper = mapper;
            _repository = repository;
        }
        public async Task<bool> checkUserNamePassword(string UserName, string Password)
        {
           return await _repository.checkUserNamePassword(UserName, Password);
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(UserModelBind model)
        {
            await _repository.InsertAsync(Mapper.Map<UserTbl>(model));
        }

        public async Task UpdateAsync(UserModelBind model)
        {
            await _repository.UpdateAsync(Mapper.Map<UserTbl>(model));
        }
    }
}
