using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForceManagement.Domain
{
    public class Profile
    {
        [Key]
        public int profile_id { get; set; }
        public string profile_name { get; set; }
        public ICollection<Employees> employees { get; set; }
    }
}
