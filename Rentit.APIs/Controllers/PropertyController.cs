using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentit.BL;
using Rentit.BL.Dtos;

namespace Rentit.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyManager PropertyManager;
        private readonly IRequestHostManger RequestHostManager;

        public PropertyController(IPropertyManager _PropertyManager , IRequestHostManger _RequestHostManager)
        {
            this.PropertyManager = _PropertyManager;
            this.RequestHostManager = _RequestHostManager;
        }

        #region Simple Crud
        [HttpGet]
        public ActionResult<List<ListPropertyReadDto>> GetAll()
        {
            return PropertyManager.GetAll().ToList();    
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ListPropertyReadDto> GetPropertyById(int id)
        {
            ListPropertyReadDto? property = PropertyManager.GetById(id); 
            if (property == null) { return NotFound(); }
            return property;    
        }
        [HttpPost]
        public ActionResult Add(PropertyAddDto PropToAdd)
        {
            var newId = RequestHostManager.AddRequestHost(PropToAdd);
            return Ok();
        }

        [HttpPost]
        [Route("Add/{id}")]
        public ActionResult AcceptRequest (int id)
        {
            RequestHostManager.AcceptRequestByAdmin(id);
            PropertyManager.Add(id);
            return Created();
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
        #endregion

        [HttpGet]
        [Route("/Details/{id}")]
        public ActionResult<PropertyReadDetailsDto> GetPropertyDetails (int id)
        {
            PropertyReadDetailsDto? property = PropertyManager.GetPropertyDetails(id);
            if (property == null) { return NotFound(); }
            return property;
        }
    }
}
