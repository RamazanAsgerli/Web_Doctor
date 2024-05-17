using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace WEB_Doctor.Controllers
{
    public class HomeController : Controller
    {

        IDoctorService _doctorService;

        public HomeController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            List<Doctor> doctor = _doctorService.GetAllDoctors();
            return View(doctor);
        }


    }
}