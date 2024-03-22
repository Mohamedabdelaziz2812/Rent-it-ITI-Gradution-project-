using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentit.BL;
using Rentit.BL.Dtos;
using Rentit.DAL;

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
        public ActionResult Update (PropertyUpdateDto PropToUpdate)
        {
            var isFound = PropertyManager.Update(PropToUpdate);
            if (!isFound) { return NotFound(); } 
              return NoContent();   
        }

        [HttpDelete]    
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
        [Route("Rent/{propertyid}")]
        public ActionResult Rent([FromBody] RequestRentAddDto ReqToAdd, [FromRoute] int propertyid)
        {
           var IsFound = requestRentManager.AddRequest(ReqToAdd, propertyid);
            if (!IsFound) { return BadRequest("Invalid Entry check your user id or you number of guests"); }    
            return Ok();
        }
       
    }
}
