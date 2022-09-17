using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users.Application.RestAPI.src;
using users.Domain.DTO;
using users.Domain.Services.Service;
using users.Domain.Services.Service.IServices;

namespace users.Application.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserService _createUser;
        private readonly IUpdateUserService _updateUser;
        private readonly IDisableUserService _disableUser;
        private readonly IDeleteUserService _deleteUser;
        private readonly IReadUserService _readUser;

        public UserController(ICreateUserService create,
                              IUpdateUserService update,
                              IDisableUserService disable,
                              IDeleteUserService delete,
                              IReadUserService read)
        {
            _createUser = create;
            _updateUser = update;
            _disableUser = disable;
            _deleteUser = delete;
            _readUser = read;
        }

        [HttpPost("NewUser")]
        public ActionResult NewUser(UserInsertDTO user)
        {
            try
            {
                var serviceResult = _createUser.CreateUser(user);

                if (serviceResult.GetType().Name.Equals("ServiceResult"))
                {
                    var obj = new ServiceResult();
                    obj = (ServiceResult)serviceResult;

                    return BadRequest(new ApiResponse(401, obj.Message));
                }

                return Ok(new ApiOKResponse(serviceResult));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServiceException.ThrowExeption(ex));
            }
        }

        [HttpPut("UpdateUser")]
        public ActionResult UpdateUser(UserReadDTO user)
        {
            try
            {
                var serviceResult = _updateUser.UpdateUser(user);

                if (serviceResult.GetType().Name.Equals("ServiceResult"))
                {
                    var obj = new ServiceResult();
                    obj = (ServiceResult)serviceResult;

                    return BadRequest(new ApiResponse(401, obj.Message));
                }
                int result = (int)serviceResult;

                if (result > 0)
                    return Ok(new ApiOKResponse(String.Format("Usuário atualizado com sucesso.")));

                return BadRequest(new ApiResponse(401, "Erro ao atualizar dados do usuário."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServiceException.ThrowExeption(ex));
            }
        }

        [HttpGet("SearchUser/{Id}")]
        public ActionResult SearchUser(int Id)
        {
            try
            {
                var serviceResult = _readUser.ReadUser(Id);

                if (serviceResult == null)
                    return NotFound(new ApiResponse(404, "Não foi possivel encontrar um usuário com esse Id."));

                return Ok(new ApiOKResponse((UserReadDTO)serviceResult));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServiceException.ThrowExeption(ex));
            }
        }

        [HttpDelete("DeleteUser/{Id}")]
        public ActionResult DeleteUser(int Id)
        {
            try
            {
                var serviceResult = _deleteUser.DeleteUser(Id);

                int result = (int)serviceResult;

                if (result > 0)
                    return Ok(new ApiOKResponse(String.Format("Usuário deletado com sucesso.")));

                return BadRequest(new ApiResponse(401, "Erro ao deletar dados do usuário."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServiceException.ThrowExeption(ex));
            }
        }

        [HttpDelete("DisableUser/{Id}")]
        public ActionResult DisableUser(int Id)
        {
            try
            {
                var serviceResult = _disableUser.DisableUser(Id);

                int result = (int)serviceResult;

                if (result > 0)
                    return Ok(new ApiOKResponse(String.Format("Usuário desativado com sucesso.")));

                return BadRequest(new ApiResponse(401, "Erro ao desativar dados do usuário."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ServiceException.ThrowExeption(ex));
            }
        }
    }
}
