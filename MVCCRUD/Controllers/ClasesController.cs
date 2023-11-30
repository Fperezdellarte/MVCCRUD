using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;
using MVCCRUD.DTO;
using MVCCRUD.Repository;


namespace MVCCRUD.Controllers
{

    public class ClasesController : Controller
    {
        private readonly ClaseRepository _claseRepo;

        public ClasesController(ClaseRepository repository)
        {
            _claseRepo = repository;
        }

        public IActionResult Index()
        {
            var clases = _claseRepo.ObtenerClases();
            var datos = clases.Select(p => new ClaseDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Profesor = p.Profesor,
                DiaClase = p.DiaClase
            }).ToList();
            return View(datos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClaseDTO claseDTO)
        {
            if (ModelState.IsValid)
            {
                var clase = new Clase
                {
                    Nombre = claseDTO.Nombre,
                    Profesor = claseDTO.Profesor,
                    DiaClase = claseDTO.DiaClase
                };
                _claseRepo.AgregarClase(clase);
                return RedirectToAction("Index");
            }

            return View(claseDTO);
        }

        public IActionResult Edit(int id)
        {
            var clase = _claseRepo.ObtenerClases().FirstOrDefault(p => p.Id == id);

            if (clase == null)
                return NotFound();

            var claseDTO = new ClaseDTO
            {
                Id = clase.Id,
                Nombre = clase.Nombre,
                Profesor = clase.Profesor,
                DiaClase = clase.DiaClase
            };
            return View(claseDTO);
        }

        [HttpPost]
        public IActionResult Edit(ClaseDTO claseDTO)
        {
            if (ModelState.IsValid)
            {
                var clase = new Clase
                {
                    Id = claseDTO.Id,
                    Nombre = claseDTO.Nombre,
                    Profesor = claseDTO.Profesor,
                    DiaClase = claseDTO.DiaClase
                };
                _claseRepo.ActualizarClase(clase);
                return RedirectToAction("Index");
            }

            return View(claseDTO);
        }

        public IActionResult Delete(int id)
        {
            var clase = _claseRepo.ObtenerClases().FirstOrDefault(p => p.Id == id);

            if (clase == null)
                return NotFound();

            var claseDTO = new ClaseDTO
            {
                Id = clase.Id,
                Nombre = clase.Nombre,
                Profesor = clase.Profesor,
                DiaClase = clase.DiaClase
            };
            return View(claseDTO);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _claseRepo.EliminarClase(id);
            return RedirectToAction("Index");
        }
    }
}