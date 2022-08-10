using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using msa_backend_assignment.Models;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace msa_backend_assignment
{

    [ApiController]
    [Route("[controller]")]
    public class PokeController : ControllerBase
    {
        private readonly HttpClient _client;
        public PokeController(IHttpClientFactory clientFactory)
        {
            if(clientFactory == null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }

            _client = clientFactory.CreateClient("pokemon");
        }

        /// <summary>
        /// Gets the raw JSON for the hot feed in reddit
        /// </summary>
        /// <returns>A JSON object representing the hot feed in reddit</returns>
        [HttpGet]
        [Route("ability")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetPokemonByAbilityName(string name)
        {
            var res = await _client.GetAsync("ability/" + name);

            if(res == null)
            {
                return NotFound("Ability not found!");
            }

            

            var content = await res.Content.ReadAsStringAsync();
            Ability json = JsonSerializer.Deserialize<Ability>(content);

            //Deserialize all pokemons and add them into list.
            List<Pokeman> pokemonList = await ConvertToList(json);

            pokemonList.Sort((x, y) => y.stats[0].base_stat.CompareTo(x.stats[0].base_stat));

            return Ok(pokemonList);
        }

        public async Task<List<Pokeman>> ConvertToList(Ability ability)
        {
            List<Pokeman> pokemonList = new List<Pokeman>();
            for (int i = 0; i < ability.pokemon.Count; i++)
            {
                var data = await _client.GetAsync("pokemon/" + ability.pokemon[i].pokemon.name);
                var content2 = await data.Content.ReadAsStringAsync();
                Pokeman newJson = JsonSerializer.Deserialize<Pokeman>(content2);
                pokemonList.Add(newJson);
            }

            return pokemonList;
        }

        

    }
}
