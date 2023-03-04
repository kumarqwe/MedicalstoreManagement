using MedicalstoreManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using MedicalstoreManagement.Repository;

namespace MedicalstoreManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailsController : Controller
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly medical_store_management_systemDbContext _DbContext;

        public EventDetailsController(IJWTManagerRepository _jWTManager, medical_store_management_systemDbContext dbContext)
        {
            this._jWTManager = _jWTManager;
            this._DbContext = dbContext;
        }

        [HttpGet("Getevent")]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult Getevent()
        {

            List<EventDetails> eventdetails = _DbContext.EventDetails.ToList();

            return StatusCode(200, eventdetails);

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
