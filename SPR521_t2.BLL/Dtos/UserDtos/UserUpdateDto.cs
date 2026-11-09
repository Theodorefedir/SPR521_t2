using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR521_t2.BLL.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public string UserName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
