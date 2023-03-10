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
    public class InvitationController : ControllerBase
    {
        private ILoggerService _logger;
        private readonly medical_store_management_systemDbContext _DbContext;

        public InvitationController( medical_store_management_systemDbContext dbContext, ILoggerService logger)
        {
            
            this._DbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("Invitation")]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult Invitation()
        {
            try
            {
                _logger.LogInfo("Fetching All invitation details");
                List<Invitation> invitations = _DbContext.Invitation.ToList();
                _logger.LogInfo($"Total medicine booking count: {invitations.Count}");
                return StatusCode(200, invitations);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching the booking medicines: {ex.Message}");
                return StatusCode(500, "Internal server error occurred while fetching the booking medicines.");
                throw;
            }

        }
        [HttpPost]
        public IActionResult AddBooking(Invitation invitations)
        {
            try
            {
                _logger.LogInfo("Adding new booking medicine");

                _DbContext.Invitation.Add(invitations);
                _DbContext.SaveChanges();

                _logger.LogInfo($"Booking medicine added: {invitations}");
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
