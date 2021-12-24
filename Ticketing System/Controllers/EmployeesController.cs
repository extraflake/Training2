using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ticketing_System.Base;
using Ticketing_System.Models;
using Ticketing_System.Repository.Data;
using Ticketing_System.ViewModel;

namespace Ticketing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController <Employee, EmployeeRepository, string>
    {
        private EmployeeRepository employeeRepository;

        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Post(RegisterVM registerVm)
        {
            var result = employeeRepository.Register(registerVm);
            if (result == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Berhasil Register" });
            }
            else if (result == 2)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result, messege = "Register Gagal, NIK sudah terdaftar" });
            }
            else if (result == 3)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result, messege = "Register Gagal, Email sudah terdaftar" });
            }
            {
            return NotFound(new { HttpStatusCode.NotFound, result, messege = "Register Gagal" });
            }
        }
    }
}
