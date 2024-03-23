using Azure.Core;
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
        [Authorize(Policy ="UserRole")]
        [Route("UserInfo")]
        public ActionResult<UserDto> GetUserDetails() 
        {
            int userid = Convert.ToInt32( HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
            UserDto? user = UserManager.GetUserDetails(userid); 
            if (user == null) { return NotFound(); }
            return user;
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public ActionResult UpdateUser (UserUpdateDto UserDto)
        {
            var IsFound = UserManager.UpdateUser(UserDto);
            if (!IsFound) { return NotFound(); }
            return Ok("User Updated Successfully");
        }

        [HttpPost]
        [Authorize(Policy = "UserRole")]
        [Route("Host")]
        public ActionResult AddRequestHost(PropertyAddDto PropToAdd) 
        {
            int userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var newId = requestHostManager.AddRequestHost(PropToAdd,userid);
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "AdminRole")]
        [Route("Add/{id}")]
        public ActionResult AcceptRequestHost(int id) 
        {
            var IsFound = requestHostManager.AcceptHostRequestByAdmin(id);
            if(!IsFound) { return NotFound("Cant find the request please add your request for hosting"); } 
            PropertyManager.Add(id);
            return Created();
        }

        [HttpPut]
        [Authorize(Policy = "AdminRole")]
        [Route("Cancel/{id}")]
        public ActionResult CancelRequestHost(int id)
        {
            var IsFound = requestHostManager.CancelHostRequestByAdmin(id);
            if (!IsFound) { return NotFound("Cant find the request please add your request for hosting"); }
        
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "UserRole")]
        [Route("AcceptRentHost/{id}")]
        public ActionResult AcceptRentRequestbyHost(int id) 
        {
            var IsFound =  requestRentManager.AcceptByHost(id);
            if (!IsFound) { return NotFound("Cant find the property"); }
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "UserRole")]
        [Route("CancelRentHost/{id}")]
        public ActionResult CancelRentRequestbyHost(int id)
        {
            var IsFound = requestRentManager.CancelByHost(id);
            if (!IsFound) { return NotFound("Cant find the property"); }
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "AdminRole")]
        [Route("AcceptRentAdmin/{id}")]
        public ActionResult AcceptRentRequestByAdmin(int id)
        {
          var IsFound =   requestRentManager.AcceptByAdmin(id);
            if (!IsFound) { return BadRequest("Cant find the request or the host acceptence still pending"); }
            return Created();
        }

        [HttpPut]
        [Authorize(Policy = "AdminRole")]
        [Route("CancelRentAdmin/{id}")]
        public ActionResult CancelRentRequestByAdmin(int id)
        {
            var IsFound = requestRentManager.CancelByAdmin(id);
            if (!IsFound) { return BadRequest("Cant find the request"); }
            return Ok();
        }

        [HttpGet]
        [Authorize(Policy = "AdminRole")]
        [Route("Rent")]
        public ActionResult<List<RequestRentReadDto>> GetAllRentRequests()
        {
            return requestRentManager.GetAllForAdmin().ToList();
        }

        [HttpGet]
        [Authorize(Policy = "AdminRole")]
        [Route("Host")]
        public ActionResult<List<RequestHostReadDto>> GetAllHostRequest()
        {
            return requestHostManager.GetAll().ToList();    
        }
    }
}
