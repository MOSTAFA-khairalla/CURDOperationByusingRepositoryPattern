using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication23.Models;

namespace WebApplication23.Repository
{
   public interface IPetRepository
    {

        void Create(Pet pet);
        void Edit(Pet pet);
        void Delete(Pet pet);
        Pet GetSinglePet(int id);
        List<Pet> GetAllPets();
    }
}
