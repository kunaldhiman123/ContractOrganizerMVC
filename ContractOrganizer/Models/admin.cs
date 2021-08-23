using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractOrganizer.Models
{
    public class admin
    {
        // model of admin page
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
