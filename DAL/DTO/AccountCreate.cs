using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class AccountCreate
    {
        public AccountCreate() { }
        public string email { get; set; }
        public string password { get; set; }
    }
}
