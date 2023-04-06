using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contacts
{
    public interface ICarRepository : IGenericDataRepository<CarTbl, int>
    {
        Task<IEnumerable<CarTbl>> GetAllCarsByMakeId(int MakeId);
        Task<IEnumerable<CarTbl>> GetAllCarsByMakeName(string MakeName);
    }
}
