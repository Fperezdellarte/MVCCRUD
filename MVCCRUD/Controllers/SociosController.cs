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

    public class SociosController : Controller
    {
        private readonly SocioRepository _socioRepo;

        public SociosController(SocioRepository repository)
        {
            _socioRepo = repository;
        }

        public IActionResult Index()
        {
            var socios = _socioRepo.ObtenerSocios();
            var datos = socios.Select(p => new SocioDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                FechaIngreso = p.FechaIngreso,
                Dni = p.Dni,
            }).ToList();
            return View(datos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SocioDTO socioDTO)
        {
            if (ModelState.IsValid)
            {
                var socio = new Socio
                {
                    Nombre = socioDTO.Nombre,
                    FechaIngreso = socioDTO.FechaIngreso,
                    Dni = socioDTO.Dni
                };
               _socioRepo.AgregarSocio(socio);
                return RedirectToAction("Index");
            }

            return View(socioDTO);
        }

        public IActionResult Edit(int id)
        {
            var socio = _socioRepo.ObtenerSocios().FirstOrDefault(p=>p.Id == id);

            if(socio == null )
                return NotFound();

            var socioDTO = new SocioDTO
            {
                Id = socio.Id,
                Nombre = socio.Nombre,
                FechaIngreso = socio.FechaIngreso,
                Dni = socio.Dni
            };
            return View(socioDTO);
        }

        [HttpPost]
        public IActionResult Edit(SocioDTO socioDTO)
        {
            if (ModelState.IsValid)
            {
                var socio = new Socio
                {
                    Id = socioDTO.Id,
                    Nombre = socioDTO.Nombre,
                    FechaIngreso = socioDTO.FechaIngreso,
                    Dni = socioDTO.Dni
                };
                _socioRepo.ActualizarSocio(socio);
                return RedirectToAction("Index");
            }

            return View(socioDTO);
        }

        public IActionResult Delete(int id)
        {
            var socio = _socioRepo.ObtenerSocios().FirstOrDefault(p => p.Id == id);

            if (socio == null)
                return NotFound();

            var socioDTO = new SocioDTO
            {
                Id = socio.Id,
                Nombre = socio.Nombre,
                FechaIngreso = socio.FechaIngreso,
                Dni = socio.Dni
            };
            return View(socioDTO);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _socioRepo.EliminarSocio(id);
            return RedirectToAction("Index");
        }
    }
}
