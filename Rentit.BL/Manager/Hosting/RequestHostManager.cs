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
        public int AcceptRequestByAdmin(int requestID)
        {
            RequestHost? request = requestHostRepo.GetByID(requestID);
            if (request == null) { return -1; }
            request.Request_StateID = 2;
            request.Message = "Your Request For Hosting your property is accecpted ";
            requestHostRepo.Update(request);
            requestHostRepo.SaveChanges();
            return request.Id;
        }

        public int AddRequestHost(PropertyAddDto propertyAdd)
        {
            RequestHost addrequestHost = new()
            {
                UserID = propertyAdd.HostId,
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
            return addrequestHost.Id;
        }
    }
}
