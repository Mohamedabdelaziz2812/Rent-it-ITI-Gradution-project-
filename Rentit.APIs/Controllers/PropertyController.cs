using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentit.BL;
using Rentit.BL.Dtos;
using Rentit.DAL;
using System.Security.Claims;

namespace Rentit.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyManager PropertyManager;
        private readonly IRequestHostManger RequestHostManager;
        private readonly IRequestRentManager requestRentManager;
        private readonly IPropertyRepo PropertyRepo;

        public PropertyController(IPropertyManager _PropertyManager ,
            IRequestHostManger _RequestHostManager, IRequestRentManager _requestRentManager,IPropertyRepo _propertyRepo)
        {
            this.PropertyManager = _PropertyManager;
            this.RequestHostManager = _RequestHostManager;
            this.requestRentManager = _requestRentManager;
            this.PropertyRepo = _propertyRepo;  

        }
        [HttpGet]
        public ActionResult<List<ListPropertyReadDto>> GetAll()
        {
            return PropertyManager.GetAll().ToList();    
        }

        [HttpPut]
        [Authorize(Policy = "UserRole")]
        public ActionResult Update (PropertyUpdateDto PropToUpdate)
        {
            var isFound = PropertyManager.Update(PropToUpdate);
            if (!isFound) { return NotFound(); } 
              return NoContent();   
        }

        [HttpDelete]
        [Authorize(Policy = "UserRole")]
        public ActionResult Delete(int id)
        {
            var isFound = PropertyManager.Delete(id);
            if (!isFound) { return NotFound(); }
            return NoContent(); 
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult<PropertyReadDetailsDto> GetPropertyDetails (int id) 
        {
            PropertyReadDetailsDto? property = PropertyManager.GetPropertyDetails(id);
            if (property == null) { return NotFound(); }
            return property;
        }

        [HttpPost]
        [Authorize(Policy ="UserRole")]
        [Route("Rent/{propertyid}")]
        public ActionResult Rent([FromForm] RequestRentAddDto ReqToAdd, [FromRoute] int propertyid)
        {
            int userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var IsFound = requestRentManager.AddRequest(ReqToAdd, propertyid,userid);
            if (!IsFound) { return BadRequest("Invalid Entry check your user id or you number of guests"); }    
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "UserRole")]
        [Route("AddReview/{PropertyId}")]
        public ActionResult AddReview([FromForm]ReviewAddDto Review,[FromRoute] int PropertyId)
        {
            int userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            PropertyManager.AddReview(Review, PropertyId,userid);
            return Ok();
        }
       
    }
}
