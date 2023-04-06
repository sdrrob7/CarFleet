using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contacts
{
    public interface IGenericService<TOut, TIn, Ttype> where TOut : class where TIn : class
    {
        Task<IEnumerable<TOut>> GetAllAsync();
        Task<TOut> GetByIdAsync(Ttype Id);
        Task InsertAsync(TIn entity);
        Task UpdateAsync(TIn entity);
        Task DeleteAsync(Ttype Id);
    }
}
