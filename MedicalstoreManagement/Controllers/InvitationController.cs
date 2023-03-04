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
    public class InvitationController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly medical_store_management_systemDbContext _DbContext;

        public InvitationController(IJWTManagerRepository _jWTManager, medical_store_management_systemDbContext dbContext)
        {
            this._jWTManager = _jWTManager;
            this._DbContext = dbContext;
        }

        [HttpGet("Invitation")]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult Invitation()
        {

            List<Invitation> invitations = _DbContext.Invitation.ToList();

            return StatusCode(200, invitations);

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
