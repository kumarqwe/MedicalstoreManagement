using MedicalstoreManagement.Models;
using MedicalstoreManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MedicalstoreManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingMedicineController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly medical_store_management_systemDbContext _DbContext;

        public BookingMedicineController(IJWTManagerRepository _jWTManager, medical_store_management_systemDbContext dbContext)
        {
            this._jWTManager= _jWTManager;
            this._DbContext = dbContext;
        }
        

        [HttpGet]
        [ServiceFilter(typeof(ActionFilterExamp))]
        public IActionResult GetBooking()
        {

            List<BookingMedicine> bookingMedicines = _DbContext.BookingMedicine.ToList();
           
         return StatusCode(200,bookingMedicines);

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
