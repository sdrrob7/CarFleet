using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contacts
{
    public interface IMakeRepository : IGenericDataRepository<MakeTbl, int>
    {
        Task<MakeTbl> GetByNameAsync(string name);
    }
}
