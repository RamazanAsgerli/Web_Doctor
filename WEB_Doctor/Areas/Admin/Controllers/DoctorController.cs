﻿using Business.CustomException;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Mvc;
using System.Composition;

namespace WEB_Doctor.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
      private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            List<Doctor> doctors = _doctorService.GetAllDoctors();
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Doctor doctor)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                _doctorService.AddDoctor(doctor);
            }catch(PhotoFileException ex)
            {
                ModelState.AddModelError(ex.V, ex.Message);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(ex.V, ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            _doctorService.RemoveDoctor(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Update(int id,Doctor doctor)
        {

            try
            {
                _doctorService.UpdateDoctor(id, doctor);
            }catch(PhotoFileException ex)
            {
                ModelState.AddModelError(ex.V, ex.Message);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(ex.V, ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }








            return RedirectToAction(nameof(Index));
        }
    }
}
