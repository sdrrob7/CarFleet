using AutoMapper;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModelBind, DataAccess.Entities.UserTbl>();

            CreateMap<DataAccess.Entities.UserTbl, UserViewModel>();
        }
    }
}
