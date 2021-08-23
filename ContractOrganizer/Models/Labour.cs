using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractOrganizer.Models
{
    public class Labour
    {
        // labour table
        public int id { get; set; }

        [Display(Name = " Name")]
        public string Name { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }


        [Display(Name = "Address")]
        public string Address { get; set; }



        [Display(Name = "Date")]
        public DateTime dTime { get; set; }




    }
}
