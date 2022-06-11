using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security.Dtos
{
    public class UserForPasswordChangeDto:UserForLoginDto
    {
        public string NewPassword { get; set; }
    }
}
