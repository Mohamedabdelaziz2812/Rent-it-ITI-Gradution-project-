using Azure.Core;
using Rentit.BL.Dtos;
using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rentit.BL
{
    public class RequestRentManager : IRequestRentManager
    {
        private readonly IPropertyRepo propertyRepo;
        private readonly IRequestRentRepo requestrentRepo;

        public RequestRentManager(IPropertyRepo _propertyRepo,IRequestRentRepo _requestRentrepo)
        {
            this.propertyRepo = _propertyRepo;
            this.requestrentRepo = _requestRentrepo;    
        }

        public bool AcceptByAdmin(int propertyid)
        {
            RequestRent? request = requestrentRepo.GetByID(propertyid);
            if (request == null || request.Request_StateID_Host != 2) { return false; } 
            request.Request_StateID_Admin = 2;
            request.Message = "Your Request For Renting your property is accecpted By Website Admin";
            request.Property.StateId = 3;
            requestrentRepo.Update(request);
            requestrentRepo.SaveChanges();
            return true;   ;
        }

        public bool CancelByAdmin(int propertyid)
        {
            RequestRent? request = requestrentRepo.GetByID(propertyid);
            if (request == null || request.Request_StateID_Host != 2) { return false; }
            request.Request_StateID_Admin = 3;
            request.Message = "Your Request For Renting your property is Cancelled By Website Admin";
            request.Property.StateId = 1;
            requestrentRepo.Update(request);
            requestrentRepo.SaveChanges();
            return true; ;
        }

        public bool AcceptByHost(int propertyid)
        {
            RequestRent? request = requestrentRepo.GetByID(propertyid);
            if (request == null || request.Request_StateID_Host != 1) { return false; }
            request.Request_StateID_Host = 2;
            request.Message = "Your Request Has been accpected by the Host," +
                "Please acquire the rental fee to secure the property for rent.";
            requestrentRepo.Update(request);    
            requestrentRepo.SaveChanges();  
            return true;

        }
        public bool CancelByHost(int propertyid)
        {
            RequestRent? request = requestrentRepo.GetByID(propertyid);
            if (request == null || request.Request_StateID_Host != 1) { return false; }
            request.Request_StateID_Host = 3;
            request.Message = "Your Request Has been Cancelled by the Host";
            requestrentRepo.Update(request);
            requestrentRepo.SaveChanges();
            return true;

        }

        public bool AddRequest(RequestRentAddDto item, int propertyid)
        {
            Propertyy? property = propertyRepo.GetByID(propertyid);
            if (property == null) { return false; }
            if (property.StateId != 1) { return false; }
            if (item.NumOfGuests > property.Nums_Guests) { return false; }
            if (item.UserId == property.HostId) { return false; }
            TimeSpan timeSpan = item.Checkout_date - item.Checkin_date;
            int difference = Math.Abs(timeSpan.Days);
            double WebFee = (item.ServiceFee + (property.Nighly_Price * difference)) * 0.15;
            double total = WebFee + (property.Nighly_Price * difference) + item.ServiceFee;
            RequestRent addrequestrent = new()
            {
                UserID = item.UserId,
                HostID = property.HostId,
                PropertyId = property.Id,
                Request_StateID_Host = 1,
                Request_StateID_Admin = 1,
                Checkin_date = item.Checkin_date,
                Checkout_date = item.Checkout_date,
                StayDurationInDays = difference,
                Nightly_price = property.Nighly_Price,
                ServiceFee = item.ServiceFee,
                WebsiteFee = WebFee,
                Total_price = total,
                NumOfGuests = item.NumOfGuests,
                Message="Your request has been sent ,Please wait for the response"
            };
            requestrentRepo.Add(addrequestrent);
            requestrentRepo.SaveChanges();
            return true;
        }

     

        public IEnumerable<RequestRentReadDto> GetAllForAdmin()
        {
            IEnumerable<RequestRent> RequestRentFromDb =  requestrentRepo.GetAllForAdmin();
            return RequestRentFromDb.Select(p => new RequestRentReadDto
            {
                UsertId=p.UserID,
                UserName= $"{p.User.FName} {p.User.LName}",
                HostId=p.HostID,
                HostName= $"{p.Host.FName} {p.Host.LName}",
                PorpertyID=p.PropertyId,
                PropertyName=p.Property.Property_Name,
                Street=p.Property.Location.Street,
                City=p.Property.Location.City,  
                CheckInDate=p.Checkin_date,
                CheckOutDate=p.Checkout_date,
                Duration=p.StayDurationInDays,
                RequestStateID=p.Request_StateID_Admin,
                RequestStateName=p.Request_state_Admin.Status,
                Nightly_price=p.Nightly_price,
                Service_Fees=p.ServiceFee,
                Total_price=p.Total_price,
            });
        }

        public IEnumerable<RequestRentReadDto> GetAllForHost(int id)
        {
            IEnumerable<RequestRent> RequestRentFromDb = requestrentRepo.GetRequestsRentWithHostId(id);
            return RequestRentFromDb.Select(p => new RequestRentReadDto
            {
                UsertId = p.UserID,
                UserName = $"{p.User.FName} {p.User.LName}",
                HostId = p.HostID,
                HostName = $"{p.Host.FName} {p.Host.LName}",
                PorpertyID = p.PropertyId,
                PropertyName = p.Property.Property_Name,
                Street = p.Property.Location.Street,
                City = p.Property.Location.City,
                CheckInDate = p.Checkin_date,
                CheckOutDate = p.Checkout_date,
                Duration = p.StayDurationInDays,
                RequestStateID = p.Request_StateID_Admin,
                RequestStateName = p.Request_state_Admin.Status,
                Nightly_price = p.Nightly_price,
                Service_Fees = p.ServiceFee,
                Total_price = p.Total_price,
            });

        }

        public IEnumerable<RequestRentReadDto> GetAllForUser(int id)
        {
            IEnumerable<RequestRent> RequestRentFromDb = requestrentRepo.GetRequestsRentWithUserId(id);
            return RequestRentFromDb.Select(p => new RequestRentReadDto
            {
                UsertId = p.UserID,
                UserName = $"{p.User.FName} {p.User.LName}",
                HostId = p.HostID,
                HostName = $"{p.Host.FName} {p.Host.LName}",
                PorpertyID = p.PropertyId,
                PropertyName = p.Property.Property_Name,
                Street = p.Property.Location.Street,
                City = p.Property.Location.City,
                CheckInDate = p.Checkin_date,
                CheckOutDate = p.Checkout_date,
                Duration = p.StayDurationInDays,
                RequestStateID = p.Request_StateID_Admin,
                RequestStateName = p.Request_state_Admin.Status,
                Nightly_price = p.Nightly_price,
                Service_Fees = p.ServiceFee,
                Total_price = p.Total_price,
            });
        }
       
        
       
    }
}
