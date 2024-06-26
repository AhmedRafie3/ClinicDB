using Application.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase, IDoctorService
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost]
        public Task<List<TbClinic>> AddDoctors()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<List<TbClinic>> GetDoctors()
        {
           return _doctorService.GetDoctors();
        }
    }
}
