using Api.Core.Repositories;
using Api.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class Repositories<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;//הממשק בין היישום שלך לבין בסיס הנתונים.
        private readonly DbSet<T> _dbSet;//מייצג את הטבלה
        public Repositories(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        //get()
        public IEnumerable<T> GetAll()
        {
            //לבדוק
           // await _context.Users.Include(a => a.Albums).ToListAsync();
            return _dbSet.ToList();
        }
        //getbyid()
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        //Add()
        public T Add(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();//תשנה בטבלה
            return item;
        }
        //Update()
        public T Update(T item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
            return item;
        }
        //Delete()
        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        //GetAllWithIncludes()  כולל קשרים עם ישויות נוספות T  מחזירה את כל הרשומות של
        public IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

    }
}
