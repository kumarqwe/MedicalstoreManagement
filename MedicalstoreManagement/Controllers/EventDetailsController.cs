using MedicalstoreManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using MedicalstoreManagement.Repository;
using MedicalstoreManagement.Logger;
using System;

namespace MedicalstoreManagement.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailsController : Controller
    {
        private ILoggerService _logger;
        private readonly medical_store_management_systemDbContext _DbContext;

        public EventDetailsController( medical_store_management_systemDbContext dbContext, ILoggerService logger)
        {
          
            this._DbContext = dbContext;
            this._logger = logger;
        }

        [HttpGet("Getevent")]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult Getevent()
        {
            try
            {
                _logger.LogInfo("Fetching All Event details");
                List<EventDetails> eventdetails = _DbContext.EventDetails.ToList();
                _logger.LogInfo($"Total medicine booking count: {eventdetails.Count}");
                return StatusCode(200, eventdetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching the booking medicines: {ex.Message}");
                return StatusCode(500, "Internal server error occurred while fetching the booking medicines.");
                throw;
            }


        }
        [HttpPost]
        public IActionResult AddBooking(EventDetails eventdetails)
        {
            try
            {
                _logger.LogInfo("Adding new booking medicine");

                _DbContext.EventDetails.Add(eventdetails);
                _DbContext.SaveChanges();

                _logger.LogInfo($"Booking medicine added: {eventdetails}");
                return StatusCode(201, "Booking medicine added successfully.");
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
