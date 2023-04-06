using SharedModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contacts
{
    public interface IMakeService : IGenericService<CarMake, CarMake, int>
    {
        Task<CarMake> GetByNameAsync(string name);
    }
}
