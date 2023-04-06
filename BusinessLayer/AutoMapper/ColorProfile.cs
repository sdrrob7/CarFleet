using AutoMapper;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<CarColor, DataAccess.Entities.ColorTbl>();

            CreateMap<DataAccess.Entities.ColorTbl, CarColor>();
        }
    }
}
