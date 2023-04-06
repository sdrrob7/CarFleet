
using DataAccess.Entities;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contacts
{
    public interface ICarService : IGenericService<CarViewModel,CarModelBind, int>
    {
        Task<IEnumerable<CarViewModel>> GetAllCarsByMakeId(int MakeId);
        Task<IEnumerable<CarViewModel>> GetAllCarsByMakeName(string MakeName);
    }
}
