using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_Upg1_Kennel.Interfaces
{
    public interface IUser
    {
        public int SSO { get; set; }
        public string UserName { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
    }
}
