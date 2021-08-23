using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractOrganizer.Models
{
    public class Contract
    {
        // contract page 
        public int id { get; set; }

        [Display(Name = " Name")]
        public string Name { get; set; }


        [Display(Name = "Company")]
        public string Company { get; set; }


        [Display(Name = "Date")]
        public DateTime dTime { get; set; }


        public Labour labour { get; set; }
    }
}
