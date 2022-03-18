using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("Email",TypeName ="char(200)")]
        public string Email { get; set; }

        [Column("Password", TypeName = "char(200)")]
        public string Password { get; set; }

        [Column("Name", TypeName = "char(200)")]
        public string Name { get; set; }

        [Column("Created_at", TypeName = "DateTime")]
        public DateTime Created_at { get; set; } = DateTime.Now;

        [Column("Updated_at", TypeName = "DateTime")]
        public DateTime Updated_at { get; set; } = DateTime.Now;


    }
}
