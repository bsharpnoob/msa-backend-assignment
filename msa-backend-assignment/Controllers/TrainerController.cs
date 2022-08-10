using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using msa_backend_assignment.Models;
using msa_backend_assignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msa_backend_assignment.Controllers
{
    public class TrainerController : ControllerBase
    {

        public IRepository<Trainer,int> trainerRepository_;

        public TrainerController(IRepository<Trainer,int> trainerRepository)
        {
            trainerRepository_ = trainerRepository;
        }

        [HttpGet]
        [Route("trainers")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllTrainers()
        {
            IEnumerable<Trainer> trainers = await trainerRepository_.GetAll();

            return Ok(trainers);



        }

        public async Task<IActionResult> GetTrainerById(int id)
        {
            Trainer trainer = await trainerRepository_.GetById(id);

            if(trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        [HttpPost]
        [Route("trainers/add")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddTrainer(Trainer t)
        {
            Trainer trainer = await trainerRepository_.Create(t);

            return Created("Trainer Created!",trainer);
        }

        [HttpDelete]
        [Route("trainers/delete/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            Trainer trainer = await trainerRepository_.Delete(id);
            return Created("Trainer Deleted!", trainer);

        }

        [HttpPut]
        [Route("trainers/update/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> PutTrainer(Trainer t)
        {
            try
            {

                Trainer trainer = await trainerRepository_.Update(t);

                return Created("Updated", t);


            }
            catch
            {
                return BadRequest();
            }


        }
    }
}
