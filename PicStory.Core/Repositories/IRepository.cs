﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PicStory.CORE.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        T? GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
