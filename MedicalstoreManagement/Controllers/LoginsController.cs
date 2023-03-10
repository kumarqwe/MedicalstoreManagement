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
    public class LoginsController : ControllerBase
    {
        private ILoggerService _logger;
        private readonly IJWTManagerRepository _jWTManager;
        private readonly medical_store_management_systemDbContext _DbContext;

        public LoginsController(IJWTManagerRepository _jWTManager, medical_store_management_systemDbContext dbContext,ILoggerService logger)
        {
            this._jWTManager = _jWTManager;
            this._DbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("GetLogin")]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult GetLogin()
        {
            try
            {
                _logger.LogInfo("Fetching All login details");
                List<Logins> logins = _DbContext.Logins.ToList();
                _logger.LogInfo($"Total medicine booking count: {logins.Count}");
                return StatusCode(200, logins);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the booking medicine: {ex.Message}");
                return StatusCode(500, "Internal server error occurred while adding the booking medicine.");
                throw;
            }

        }
        
    }
}
