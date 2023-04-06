using AutoMapper;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarModelBind, DataAccess.Entities.CarTbl>();

            CreateMap<DataAccess.Entities.CarTbl, CarViewModel>()
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make.Name))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => (src.Color != null) ? src.Color.Name : ""));
        }
    }
}
