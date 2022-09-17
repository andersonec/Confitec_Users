using System;
using users.Domain.DTO;
using users.Infra.Entities;

namespace users.Infra.CrossCutting.Adapter
{
    public class UserMapper
    {
        public static User DTOToUser(UserInsertDTO userDTO)
        {
            return new User
            {
                BirthDate = Convert.ToDateTime(userDTO.BirthDate),
                Email = userDTO.Email,
                LastName = userDTO.LastName,
                Name = userDTO.Name,
                SchoolingHistoryId = userDTO.SchoolingHistoryId,
                SchoolingId = userDTO.SchoolingId,
                Status = true
            };
        }
        public static User DTOToUser(UserReadDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                BirthDate = Convert.ToDateTime(userDTO.BirthDate),
                Email = userDTO.Email,
                LastName = userDTO.LastName,
                Name = userDTO.Name,
                SchoolingHistoryId = userDTO.SchoolingHistoryId,
                SchoolingId = userDTO.SchoolingId,
                Status = userDTO.Status
            };
        }
        public static UserReadDTO UserToDTO(User userDTO)
        {
            return new UserReadDTO
            {
                Id = userDTO.Id,
                BirthDate = userDTO.BirthDate.ToString("dd/MM/yyyy"),
                Email = userDTO.Email,
                LastName = userDTO.LastName,
                Name = userDTO.Name,
                SchoolingHistoryId = userDTO.SchoolingHistoryId,
                SchoolingId = userDTO.SchoolingId,
                Status = userDTO.Status
            };
        }
    }
}
