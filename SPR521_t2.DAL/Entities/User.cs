using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR521_t2.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
