using MedicalstoreManagement.Models;
using MedicalstoreManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MedicalstoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegistrationController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly medical_store_management_systemDbContext _DbContext;

        public LoginRegistrationController(IJWTManagerRepository _jWTManager, medical_store_management_systemDbContext dbContext)
        {
            this._jWTManager = _jWTManager;
            this._DbContext = dbContext;
        }
        [HttpGet("Login")]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult Login()
        {

            List<LoginRegistration> logincontroller = _DbContext.LoginRegistration.ToList();

            return StatusCode(200, logincontroller);

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] Users usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
