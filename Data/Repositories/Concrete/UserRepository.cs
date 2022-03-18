using Data.Repositories.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(CrudContext context):base(context)
        {

        }
        public async Task<User> GetUserById(string Id)
        {
            return await DbSetInstance.FirstOrDefaultAsync(user => user.Id == new Guid(Id));
        }

        
    }
}
