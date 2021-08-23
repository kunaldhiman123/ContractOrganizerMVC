using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContractOrganizer.Models;

namespace ContractOrganizer.Data
{
    public class ContractOrganizerContext : DbContext
    {
        public ContractOrganizerContext (DbContextOptions<ContractOrganizerContext> options)
            : base(options)
        {
        }

        public DbSet<ContractOrganizer.Models.admin> admin { get; set; }

        public DbSet<ContractOrganizer.Models.Labour> Labour { get; set; }

        public DbSet<ContractOrganizer.Models.Contract> Contract { get; set; }

        public DbSet<ContractOrganizer.Models.Attendance> Attendance { get; set; }
    }
}
