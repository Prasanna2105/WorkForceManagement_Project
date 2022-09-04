using System.ComponentModel.DataAnnotations;

namespace WorkForceManagement.Domain
{
    public class Employees
    {
        [Key]
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string status { get; set; }
        public string manager { get; set; }
        public string wfm_manager { get; set; }
        public string email { get; set; }
        public string lockstatus { get; set; }
        public decimal experience { get; set; }
        public int profile_id { get; set; }
        public Profile profile { get; set; }
        public IList<Skillmap> skillmaps { get; set; }
        public IList<Softlock> softlocks { get; set; }
    }
}