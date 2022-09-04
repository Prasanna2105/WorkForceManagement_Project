using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkForceManagement.Domain
{
    public class Users
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string email { get; set; }


    }
}
