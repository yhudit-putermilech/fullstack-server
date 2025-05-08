using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Services
{
    public interface IRepositoryService<T> where T : class
    {
        //מחזיר הכול
        Task<IEnumerable<T>> GetAllAsync();
        //ID מחזיר לפי
        Task<T> GetByIdAsync(int id);
        //להוסיף ערך
        Task AddValueAsync(T entity);
        //לעדכן ערך
        Task PutValueAsync(T entity);
        //למחוק ערך
        Task DeleteAsync(T a);
    }
}
