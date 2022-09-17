using System;
using users.Infra.Entities;

namespace users.Domain.DTO
{
    public class UserInsertDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public int SchoolingId { get; set; }
        public int SchoolingHistoryId { get; set; }
    }

    public class UserReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public int SchoolingId { get; set; }
        public int SchoolingHistoryId { get; set; }
        public bool Status { get; set; }
    }
}
