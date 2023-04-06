using AutoMapper;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<CarModel, DataAccess.Entities.ModelTbl>();

            CreateMap<DataAccess.Entities.ModelTbl, CarModel>();
        }
    }
}
