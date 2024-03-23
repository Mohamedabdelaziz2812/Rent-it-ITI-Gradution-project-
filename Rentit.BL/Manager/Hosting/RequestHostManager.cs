using Rentit.BL.Dtos;
using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public class RequestHostManager : IRequestHostManger
    {
        private readonly IRequestHostRepo requestHostRepo;

        public RequestHostManager(IRequestHostRepo _requestHostRepo)
        {
            this.requestHostRepo = _requestHostRepo;    
        }
        public bool AcceptHostRequestByAdmin(int requestID)
        {
            RequestHost? request = requestHostRepo.GetByID(requestID);
            if (request == null) { return false; }
            request.Request_StateID = 2;
            request.Message = "Your Request For Hosting your property is accecpted ";
            requestHostRepo.Update(request);
            requestHostRepo.SaveChanges();
            return true;
        }

        public bool CancelHostRequestByAdmin(int requestID)
        {
            RequestHost? request = requestHostRepo.GetByID(requestID);
            if (request == null) { return false; }
            request.Request_StateID = 3;
            request.Message = "Your Request For Hosting your property is Cancelled ";
            requestHostRepo.Update(request);
            requestHostRepo.SaveChanges();
            return true;
        }

        public bool AddRequestHost(PropertyAddDto propertyAdd,int userid)
        {
            RequestHost addrequestHost = new()
            {
                UserID = userid,
                Request_StateID = 1,
                Property_Name = propertyAdd.Property_Name,
                Nighly_Price = propertyAdd.Nighly_Price,
                Description = propertyAdd.Description,
                Nums_Bathrooms = propertyAdd.Nums_Bathrooms,
                Nums_Bedrooms = propertyAdd.Nums_Bedrooms,
                Nums_Beds = propertyAdd.Nums_Beds,
                Nums_Guests = propertyAdd.Nums_Guests,
                PlaceType_ID = propertyAdd.PlaceType_ID,
                PropetyTypeId = propertyAdd.PropetyTypeId,
                Street = propertyAdd.Street,
                Building_name = propertyAdd.Building_name,
                Building_no = propertyAdd.Building_no,
                City = propertyAdd.City,
                District_name = propertyAdd.District_name,
                Location_url = propertyAdd.Location_url,
                GovernateId = propertyAdd.GovernateId
            };
            requestHostRepo.Add(addrequestHost);
            requestHostRepo.SaveChanges();
            return true;
        }

        public IEnumerable<RequestHostReadDto> GetAll()
        {
            IEnumerable<RequestHost> requestHosts = requestHostRepo.GetAll();
            return requestHosts.Select(i => new RequestHostReadDto
            {
                UserID = i.UserID,
                Request_StateID = i.Request_StateID,
                Request_State = i.Request_state.Status,
                Property_Name = i.Property_Name,
                Nighly_Price = i.Nighly_Price,
                Description = i.Description,
                Nums_Bathrooms = i.Nums_Bathrooms,
                Nums_Bedrooms = i.Nums_Bedrooms,
                Nums_Beds = i.Nums_Beds,
                Nums_Guests = i.Nums_Guests,
                Street = i.Street,
                City = i.City,
                Building_name = i.Building_name,
                Building_no = i.Building_no,
                District_name = i.District_name,
                Location_url = i.Location_url,
                GovernateId = i.GovernateId,
                governate = i.governate.Name,
                PlaceType_ID = i.PlaceType_ID,
                Place_Type = i.Place_Type.Name,
                PropetyTypeId = i.PropetyTypeId,
                Property_Type = i.Property_Type.Name,
            });
        }
    }
}
