using Azure.Core;
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
    public class UserController : ControllerBase
    {
        private readonly IClientManager UserManager;
        private readonly IRequestHostManger requestHostManager;
        private readonly IPropertyManager PropertyManager;
        private readonly IRequestRentManager requestRentManager;
        public UserController(IClientManager _userManager ,IRequestHostManger _RequestHostManager
            ,IPropertyManager _PropertyManager , IRequestRentManager _requestRentManager)
        {
            this.UserManager = _userManager;   
            this.requestHostManager = _RequestHostManager;
            this.PropertyManager = _PropertyManager;
            this.requestRentManager = _requestRentManager;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserDto> GetUserById(int id) 
        {
            UserDto? user = UserManager.GetUserDetails(id); 
            if (user == null) { return NotFound(); }
            return user;
        }

        [HttpPost]
        [Route("Host")]
        public ActionResult AddRequestHost(PropertyAddDto PropToAdd) 
        {
            var newId = requestHostManager.AddRequestHost(PropToAdd);
            return Ok();
        }

        [HttpPost]
        [Route("Add/{id}")]
        public ActionResult AcceptRequestHost(int id) 
        {
            var IsFound = requestHostManager.AcceptHostRequestByAdmin(id);
            if(!IsFound) { return NotFound("Cant find the request please add your request for hosting"); } 
            PropertyManager.Add(id);
            return Created();
        }

        [HttpPut]
        [Route("User/{id}")]
        public ActionResult AcceptRentRequestbyHost(int id) 
        {
            var IsFound =  requestRentManager.AcceptByHost(id);
            if (!IsFound) { return NotFound("Cant find the property"); }
            return Ok();
        }
        
        [HttpPut]
        [Route("Admin/{id}")]
        public ActionResult AcceptRentRequest(int id)
        {
          var IsFound =   requestRentManager.AcceptByAdmin(id);
            if (!IsFound) { return BadRequest("Cant find the request or the host acceptence still pending"); }
            return Created();
        }

        [HttpGet]
        [Route("Rent")]
        public ActionResult<List<RequestRentReadDto>> GetAllRentRequests()
        {
            return requestRentManager.GetAllForAdmin().ToList();
        }

        [HttpGet]
        [Route("Host")]
        public ActionResult<List<RequestHostReadDto>> GetAllHostRequest()
        {
            return requestHostManager.GetAll().ToList();    
        }
    }
}
