using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForceManagement.Domain
{
    public class Skillmap
    { 
        public int SkillmapId { get; set; }
        public int employee_id { get; set; }
        public int skillid { get; set; }
        public Employees employees { get; set; }
        public Skills skills { get; set; }
    }
}
