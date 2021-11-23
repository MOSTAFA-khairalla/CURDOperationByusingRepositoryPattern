using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication23.Data;
using WebApplication23.Models;

namespace WebApplication23.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;

        public PetRepository(ApplicationDbContext context )
        {
            _context = context;
        }
        public void Create(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
         
        }

        public void Delete(Pet pet)
        {

            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }

        public void Edit(Pet pet)
        {

            _context.Pets.Update(pet);
            _context.SaveChanges();
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets.ToList();
        }

        public Pet GetSinglePet(int id)
        {

            var pet = _context.Pets.FirstOrDefault(p => p.Id == id);
            return pet;
        }
    }
}
