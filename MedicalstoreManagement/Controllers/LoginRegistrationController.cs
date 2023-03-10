using MedicalstoreManagement.Logger;
using MedicalstoreManagement.Models;
using MedicalstoreManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalstoreManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegistrationController : ControllerBase
    {
        private ILoggerService _logger;
        private readonly IJWTManagerRepository _jWTManager;
        private readonly medical_store_management_systemDbContext _DbContext;

        public LoginRegistrationController(IJWTManagerRepository _jWTManager, medical_store_management_systemDbContext dbContext, ILoggerService _logger)
        {
            this._jWTManager = _jWTManager;
            this._DbContext = dbContext;
            this._logger = _logger;
        }
        [HttpGet("Login")]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult Login()
        {
            try
            {
                _logger.LogInfo("Fetching All login details");
                List<LoginRegistration> logincontroller = _DbContext.LoginRegistration.ToList();
                _logger.LogInfo($"Total medicine booking count: {logincontroller.Count}");
                return StatusCode(200, logincontroller);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the booking medicine: {ex.Message}");
                return StatusCode(500, "Internal server error occurred while adding the booking medicine.");
                throw;
            }

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
