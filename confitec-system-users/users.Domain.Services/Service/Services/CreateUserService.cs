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
    public class CreateUserService : ICreateUserService
    {
        private readonly IUserRepository _repository;
        public CreateUserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Object CreateUser(UserInsertDTO user)
        {
            try
            {
                var validName = Validation.IsNameValid(user.Name + " " + user.LastName);
                if (!String.IsNullOrEmpty(validName))
                    return new ServiceResult
                    {
                        CodeError = 1,
                        Message = validName
                    };

                var validEmail = Validation.IsValidEmail(user.Email);
                if (!String.IsNullOrEmpty(validEmail))
                    return new ServiceResult
                    {
                        CodeError = 1,
                        Message = validEmail
                    };

                if (Convert.ToDateTime(user.BirthDate) > DateTime.Now)
                    return new ServiceResult
                    {
                        CodeError = 1,
                        Message = "A data de nascimento não pode ser maior do que a data atual."
                    };

                var userCreated = _repository.Add(UserMapper.DTOToUser(user));

                return UserMapper.UserToDTO(userCreated);
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
