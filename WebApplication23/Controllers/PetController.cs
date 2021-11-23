using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication23.Data;
using WebApplication23.Models;
using WebApplication23.Repository;

namespace WebApplication23.Controllers
{
    public class PetController : Controller
    {
        private readonly PetRepository _petRepository;
        private readonly ApplicationDbContext _context;

        public PetController(  ApplicationDbContext context)
        {
            _context = context;

            _petRepository = new PetRepository(_context);
        }
        public IActionResult Index()
        {
            var pets = _petRepository.GetAllPets();
            return View(pets);
        }

        public IActionResult Detials(int id)
        {
            var pets = _petRepository.GetSinglePet(id);
            return View(pets);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.InEditMode = "false";
            return View();
        }

        [HttpPost]
        public IActionResult New( Pet pet,string InEditMode )
        {
            if (InEditMode.Equals("false"))
            {
                _petRepository.Create(pet);
            }
            else
            {
                _petRepository.Edit(pet);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            ViewBag.InEditMode = "true";
            var pets = _petRepository.GetSinglePet(id);
            return View("New",pets);
        }

       
        public IActionResult Delete(int id)
        {
            var pets = _petRepository.GetSinglePet(id);
            _petRepository.Delete(pets);
            return RedirectToAction("Index");

        }
    }
}
