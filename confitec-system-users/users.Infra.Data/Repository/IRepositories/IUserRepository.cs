using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users.Infra.Entities;

namespace users.Infra.Data.Repository.IRepositories
{
    public interface IUserRepository
    {
        User Add(User obj);
        User GetById(int id);
        IEnumerable<User> GetAll();
        int Update(User obj);
        int Remove(User obj);
        void Dispose();
    }
}
