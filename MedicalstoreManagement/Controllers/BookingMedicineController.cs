using MedicalstoreManagement.Models;
using MedicalstoreManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MedicalstoreManagement.ExceptionHandlerMiddleware;
using MedicalstoreManagement.Logger;
using System;

namespace MedicalstoreManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingMedicineController : ControllerBase
    {
        private ILoggerService _logger;
        private readonly IJWTManagerRepository _jWTManager;
        private readonly medical_store_management_systemDbContext _DbContext;

        public BookingMedicineController(IJWTManagerRepository _jWTManager, medical_store_management_systemDbContext dbContext,ILoggerService logger)
        {
            this._jWTManager= _jWTManager;
            this._DbContext = dbContext;
            this._logger = logger;
        }
        
        [HttpGet]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult GetBooking()
        {
            try
            {
                _logger.LogInfo("Fetching All Booking medicine");

                List<BookingMedicine> bookingMedicines = _DbContext.BookingMedicine.ToList();
                _logger.LogInfo($"Total medicine booking count: {bookingMedicines.Count}");
                return StatusCode(200, bookingMedicines);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching the booking medicines: {ex.Message}");
                return StatusCode(500, "Internal server error occurred while fetching the booking medicines.");
                throw;
            }

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody]Users usersdata)
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
