using AutoMapper;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AutoMapper
{
    public class MakeProfile : Profile
    {
        public MakeProfile()
        {
            CreateMap<CarMake, DataAccess.Entities.MakeTbl>();

            CreateMap<DataAccess.Entities.MakeTbl, CarMake>();
        }
    }
}
