using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using msa_backend_assignment.Models;

namespace msa_backend_assignment
{
    public class TrainerDb : DbContext
    {
        public TrainerDb(DbContextOptions options) : base(options) { }
        public DbSet<Trainer> Trainers { get; set; }

    }
}
