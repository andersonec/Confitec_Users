using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users.Domain.DTO;

namespace users.Domain.Services.Service.IServices
{
    public interface ICreateUserService
    {
        Object CreateUser(UserInsertDTO user);
    }
}
