using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentit.BL.Dtos;
using Rentit.BL;

namespace Rentit.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentingController : ControllerBase
    {
        private readonly IRequestRentManager RequestRentManager;

        public RentingController(IRequestRentManager _RequestRentManager)
        {
            this.RequestRentManager = _RequestRentManager;
        }
        [HttpGet]
        public ActionResult<List<RequestRentReadDto>> GetAll()
        {
            return RequestRentManager.GetAllForAdmin().ToList(); 
        }
        
        [HttpGet]
        [Route("User/{userid}")]
        public ActionResult<List<RequestRentReadDto>> GetAllForUser(int userid)
        {
            return RequestRentManager.GetAllForUser(userid).ToList();
        }
        [HttpPost]
        [Route("{propertyid}")]
        public ActionResult Rent([FromBody]RequestRentAddDto ReqToAdd,[FromRoute]int propertyid)
        {
            RequestRentManager.AddRequest(ReqToAdd,propertyid);
            return Ok();
        }
        [HttpPut]
        [Route("User/{id}")]
        public ActionResult AcceptRequestbyHost(int id)
        {
            RequestRentManager.AcceptByHost(id);    
            return Ok();
        }
        [HttpPut]
        [Route("Admin/{id}")]
        public ActionResult AcceptRequest(int id)
        {
            RequestRentManager.AcceptByAdmin(id);
            return Created();
        }
    }
}
