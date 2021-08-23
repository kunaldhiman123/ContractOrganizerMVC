using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractOrganizer.Models
{
    public class Attendance
    {
        // attendance page model
        public int id { get; set; }

        [Display(Name = " Name")]
        public string Name { get; set; }


        [Display(Name = "Date")]
        public DateTime dTime { get; set; }


        public Labour labour { get; set; }
    }
}
