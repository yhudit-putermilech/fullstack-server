using Api.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class UserRepository : Repository<UserRepository>, IUserrepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
    }
}
