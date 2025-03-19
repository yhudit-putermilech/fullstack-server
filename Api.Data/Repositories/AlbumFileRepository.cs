using Api.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class AlbumFileRepository:Repositories<AlbumFileRepository>,IAlbumRepository
    {
        public AlbumFileRepository(DataContext context):base(context)
        {
        
        }

    }
}
