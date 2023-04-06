using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contacts
{
    public interface IModelRepository : IGenericDataRepository<ModelTbl, int>
    {
    }
}
