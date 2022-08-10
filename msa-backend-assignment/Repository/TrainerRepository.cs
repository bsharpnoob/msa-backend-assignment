using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using msa_backend_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msa_backend_assignment.Repository
{
    public class TrainerRepository : IRepository<Trainer, int>
    {
        public TrainerDb trainerDb_;
        public TrainerRepository(TrainerDb trainerDb)
        {
            trainerDb_ = trainerDb;
        }
        public async Task<Trainer> Create(Trainer t)
        {
            await trainerDb_.Trainers.AddAsync(t);
            await trainerDb_.SaveChangesAsync();
            return t;
            
        }

        public async Task<Trainer> Delete(int id)
        {
            Trainer trainer = await trainerDb_.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return null;
            }

            trainerDb_.Trainers.Remove(trainer);
            await trainerDb_.SaveChangesAsync();
            return trainer;
        }

        public async Task<IEnumerable<Trainer>> GetAll()
        {
            List<Trainer> trainers = await trainerDb_.Trainers.ToListAsync();
            return trainers;

        }

        public async Task<Trainer> GetById(int id)
        {
            Trainer trainer = await trainerDb_.Trainers.FindAsync(id);
            if(trainer != null)
            {
                return trainer;
            }else
            {
                return null;
            }
        }

        public async Task<Trainer> Update(Trainer trainer)
        {
            Trainer t = await trainerDb_.Trainers.FindAsync(trainer.ID);
            if(t == null)
            {
                return null;
            }

            t.FirstName = trainer.FirstName;
            t.LastName = trainer.LastName;
            await trainerDb_.SaveChangesAsync();
            return t;
        }
    }
}
