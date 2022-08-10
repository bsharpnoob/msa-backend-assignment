using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msa_backend_assignment
{
    public class Ability
    {
        
      

       
       
        public int id { get; set; }

        public bool is_main_series { get; set; }    
        public string name { get; set; }
        
        public List<Pokemon> pokemon { get; set; }



    }

    public class Pokemon
    {
        public bool is_hidden { get; set; }
        public PokemonInfo pokemon { get; set; }
        public int slot { get; set; }


    }

    public class PokemonInfo
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
