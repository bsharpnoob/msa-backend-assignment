using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msa_backend_assignment
{
    public class Pokeman
    {
        public string name { get; set; }
        public int height { get; set; }
        public List<Stat> stats { get; set; }
    
    }

    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        
        public StatInfo stat { get; set; }

    }

    public class StatInfo
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
