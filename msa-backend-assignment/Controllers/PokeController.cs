using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using msa_backend_assignment.Models;


namespace msa_backend_assignment
{

    [ApiController]
    [Route("[controller]")]
    public class PokeController : ControllerBase
    {
        private readonly HttpClient _client;
        private TrainerDb trainerDb_;
        public PokeController(IHttpClientFactory clientFactory,TrainerDb trainerDb)
        {
            if(clientFactory == null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }

            _client = clientFactory.CreateClient("pokemon");
            trainerDb_ = trainerDb;
        }

        /// <summary>
        /// Gets the raw JSON for the hot feed in reddit
        /// </summary>
        /// <returns>A JSON object representing the hot feed in reddit</returns>
        [HttpGet]
        [Route("pokemon")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetPokemonData(string name)
        {
            var res = await _client.GetAsync("pokemon/" + name);
            var content = await res.Content.ReadAsStringAsync();
            
            return Ok(content);
        }
        
        [HttpGet]
        [Route("trainers")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetTrainers()
        {
            
            var trainers =  await trainerDb_.Trainers.ToListAsync();
            return Ok(trainers);
        }

        [HttpPost]
        [Route("trainers/add")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddTrainer(string id,string firstName,string lastName)
        {
            Trainer newTrainer = new Trainer(id,firstName,lastName);
            await trainerDb_.Trainers.AddAsync(newTrainer);
            await trainerDb_.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("trainers/delete/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteTrainer(string id)
        {
            var trainer = await trainerDb_.Trainers.FindAsync(id);
            if(trainer == null)
            {
                return NotFound("Trainer not found!");
            }

            trainerDb_.Trainers.Remove(trainer);
            await trainerDb_.SaveChangesAsync();
            return Ok("Trainer deleted");

        }

        [HttpPut]
        [Route("trainers/update/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateTrainer()
        {

        }




    }
}
