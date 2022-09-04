using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForceManagement.Domain
{
    public class Skills
    {
        [Key]
        public int skillid { get; set; }
        public string skillname { get; set; }
        public IList<Skillmap> skillmaps { get; set; }
    }
}
