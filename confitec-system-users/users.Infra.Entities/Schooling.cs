using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace users.Infra.Entities
{
    [Table("tbSchooling")]
    public class Schooling
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
