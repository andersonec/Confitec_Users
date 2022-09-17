using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace users.Infra.Entities
{
    [Table("tbUsers")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int SchoolingId { get; set; }
        public int SchoolingHistoryId { get; set; }
        public bool Status { get; set; }
    }
}
