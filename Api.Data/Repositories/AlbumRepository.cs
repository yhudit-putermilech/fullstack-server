using Api.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class AlbumRepository : Repository<AlbumRepository>, IAlbumRepository
    {
        public AlbumRepository(DataContext context) : base(context)
        {

        }
    }
}
