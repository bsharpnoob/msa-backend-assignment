using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace msa_backend_assignment.Models
{
    public class Trainer
    {
        
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Trainer(string id,string fname,string lname)
        {
            ID = id;
            FirstName = fname;
            LastName = lname;
        }

        public Trainer()
        {

        }
    }
}
