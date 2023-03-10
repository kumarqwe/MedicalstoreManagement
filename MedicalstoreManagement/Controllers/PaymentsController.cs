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
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private ILoggerService _logger;
        private readonly medical_store_management_systemDbContext _DbContext;

        public PaymentsController( medical_store_management_systemDbContext dbContext, ILoggerService logger)
        {
            
            this._DbContext = dbContext;
            this._logger = logger;

        }

        [HttpGet("Payment")]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult Payment()
        {
            try
            {
                _logger.LogInfo("Fetching All payments details");
                List<Payments> payments = _DbContext.Payments.ToList();
                _logger.LogInfo($"Total medicine booking count: {payments.Count}");
                return StatusCode(200, payments);
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
