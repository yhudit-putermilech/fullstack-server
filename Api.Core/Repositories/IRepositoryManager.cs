using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories
{
    public interface IRepositoryManager
    {

        public IRepository<User> Users { get; }
        //  public IRepository<Log> Logs { get; }
        //  public IRepository<Image> Images { get; }
        //  public IRepository<Album> Albums { get; }
        //s  public IRepository<AlbumFile> AlbumFiles { get; }
        public IUserrepository User { get; }
        Task SaveAsync();

    }
}
