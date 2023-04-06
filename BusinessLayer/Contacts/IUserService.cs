using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contacts
{
    public interface IUserService : IGenericService<UserViewModel, UserModelBind, Guid>
    {
        Task<bool> checkUserNamePassword(string UserName, string Password);
    }
}
