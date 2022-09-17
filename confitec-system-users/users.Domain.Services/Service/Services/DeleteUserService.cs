using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users.Domain.DTO;
using users.Domain.Services.Service.IServices;
using users.Infra.CrossCutting.Adapter;
using users.Infra.CrossCutting.Validation;
using users.Infra.Data.Repository.IRepositories;


namespace users.Domain.Services.Service.Services
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IUserRepository _repository;
        public DeleteUserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Object DeleteUser(int Id)
        {
            try
            {
                var user = _repository.GetById(Id);
                user.Status = false;

                return _repository.Remove(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _repository.Dispose();
            }
        }
    }
}
