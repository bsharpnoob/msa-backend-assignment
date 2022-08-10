using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msa_backend_assignment.Models
{
    public interface IRepository<T,I> where T:class
    {

        public Task<IEnumerable<Trainer>> GetAll();

        public Task<Trainer> GetById(I id);
        public Task<Trainer> Create(T t);

        public Task<Trainer> Update(T t);

        public Task<Trainer> Delete(I id);

    }
}
