using Rentit.BL.Dtos;
using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepo UserRepo;
        private readonly IRequestRentRepo requestRentRepo;

        public ClientManager(IClientRepo _UserRepo,IRequestRentRepo _RequestRentRepo)
        {
            this.UserRepo = _UserRepo;
            this.requestRentRepo= _RequestRentRepo; 
        }

        public bool AddUser(Client user)
        {
            UserRepo.AddUser(user);
            UserRepo.SaveChanges(); 
            return true;
        }

       public bool UpdateUser(UserUpdateDto UserFromRequest)
       {
            Client? User = UserRepo.GetUserDetails(UserFromRequest.Id);
            if (User  == null) { return false; }
            User.FName = UserFromRequest.FName;
            User.LName = UserFromRequest.LName;
            User.Email = UserFromRequest.Email;
            User.Img_URL = UserFromRequest.Image_URL;
            //for tracking method
            UserRepo.UpdateUser(User);
            UserRepo.SaveChanges();
            return true;
       }

       public UserDto GetUserDetails(int id)
       {
            Client user = UserRepo.GetUserDetails(id);
            List<RequestRent> allrequestrent = (List<RequestRent>)requestRentRepo.GetAllForAdmin();    
            List<RequestRent> requestRents = new List<RequestRent>();   
            List<RequestRent> myRequestRent = new List<RequestRent>();
            string Img_UrlRent ="";
            string Img_UrlHost = "";

            foreach (var item in allrequestrent)
            {
                if(item.HostID == id)
                { myRequestRent.Add(item); 
                    foreach (var img in item.Property.Property_imgs)
                    {
                        if (img.Img_order == 1)
                        {
                            Img_UrlHost = img.Img_URL;  
                        }
                    }
                } 
                if(item.UserID == id)
                { requestRents.Add(item);
                    foreach (var img in item.Property.Property_imgs)
                    {
                        if (img.Img_order == 1)
                        {
                            Img_UrlRent = img.Img_URL;
                        }
                    }
                }
            }
           return new UserDto
            {
                Id = id,
                Fname = user.FName,
                Lname = user.LName,
                Name = $"{user.FName} {user.LName}",
                Email = user.Email,
                Image_URL = user.Img_URL,
                JoinedDate = user.JoinedDate,
                Start_HostingDate = user.Start_HostingDate,
                RoleId = user.RoleId,
                Role = user.Role.Name,

                RequestsRent = requestRents.Select(i => new RequestRentReadDto
                {
                    id = i.Id,  
                    UserId = i.UserID,
                    UserName = $"{i.User.FName} {i.User.LName}",
                    HostId = i.HostID,
                    HostName = $"{i.Host.FName} {i.Host.LName}",
                    PorpertyID = i.PropertyId,
                    PropertyName = i.Property.Property_Name,
                    Street = i.Property.Location.Street,
                    District = i.Property.Location.District_name,
                    City = i.Property.Location.City,
                    CheckInDate = i.Checkin_date,
                    CheckOutDate = i.Checkout_date,
                    Duration = i.StayDurationInDays,
                    RequestStateID = i.Request_StateID_Admin,
                    RequestStateName = i.Request_state_Admin.Status,
                    Nightly_price = i.Nightly_price,
                    Service_Fees = i.ServiceFee,
                    Total_price = i.Total_price,
                    Message = i.Message,
                    Property_img= Img_UrlRent,
                    HostStateID=i.Request_StateID_Host,
                    AdminStateID=i.Request_StateID_Admin
                }).ToList(),
                RequestsRentForMyProps= myRequestRent.Select(i=> new RequestRentReadDto
                {
                    id=i.Id ,
                    UserId = i.UserID,
                    UserName = $"{i.User.FName} {i.User.LName}",
                    HostId = i.HostID,
                    HostName = $"{i.Host.FName} {i.Host.LName}",
                    PorpertyID = i.PropertyId,
                    PropertyName = i.Property.Property_Name,
                    Street = i.Property.Location.Street,
                    District = i.Property.Location.District_name,
                    City = i.Property.Location.City,
                    CheckInDate = i.Checkin_date,
                    CheckOutDate = i.Checkout_date,
                    Duration = i.StayDurationInDays,
                    RequestStateID = i.Request_StateID_Admin,
                    RequestStateName = i.Request_state_Admin.Status,
                    Nightly_price = i.Nightly_price,
                    Service_Fees = i.ServiceFee,
                    Total_price = i.Total_price,
                    Message = i.Message,
                    Property_img = Img_UrlHost,
                    HostStateID = i.Request_StateID_Host,
                    AdminStateID = i.Request_StateID_Admin
                }).ToList(),

                RequestsHost = user.RequestHosts.Select(i => new RequestHostReadDto
                {
                    id  = i.Id ,    
                    UserID = user.Id,
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
                    Message = i.Message,
                    imageToAddRequestHostDtos= i.Imgs.Select(p=> new ImageToAddRequestHostDto
                    {
                        Img_URL=p.Img_URL,
                        Img_order=p.Img_order,
                    }).ToList(),
                    attrubutesToAddDto= i.Attributes_requests.Select(p=> new AttributesChildDto
                    {
                        Id=p.Id, Name=p.Name,Icon_Url=p.Icon_Url
                    }).ToList(),    

                }).ToList(),
                UserProperties = user.Properties.Select(i => new PropertyReadDetailsDto
                {
                    Id = i.Id,
                    Property_Name = i.Property_Name,
                    Nighly_Price = i.Nighly_Price,
                    Description = i.Description,
                    Nums_Bathrooms = i.Nums_Bathrooms,
                    Nums_Bedrooms = i.Nums_Bedrooms,
                    Nums_Beds = i.Nums_Beds,
                    Nums_Guests = i.Nums_Guests,
                    Nums_Web_visitors = i.Nums_Web_visitors,
                    Host_image = i.User.Img_URL,
                    location = new LocationReadDto
                    {
                        Id = i.Loc_id,
                        Street = i.Location.Street,
                        City = i.Location.City,
                        Building_no = i.Location.Building_no,
                        Building_name = i.Location.Building_name,
                        District_name = i.Location.District_name,
                        Location_url = i.Location.Location_url,
                        governate = i.Location.Governate.Name
                    },
                    placeType = i.Place_Type.Name,
                    Property_Type = i.Property_Type.Name,
                    State = i.Property_States.Name,
                    HostId = user.Id,
                    HostName = $"{user.FName} {user.LName}",
                    Images = i.Property_imgs.Select(u => new ImageChildDto
                    {
                        Id = u.Id,
                        Img_order = u.Img_order,
                        Img_URL = u.Img_URL
                    }).ToList(),

                    attributes = i.Attributes_property.Select(a => new AttributesChildDto
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Icon_Url = a.Icon_Url
                    }).ToList(),
                }) .ToList()
            };
       }

        public int SaveChanges()
        {
            return UserRepo.SaveChanges();
        }
        public bool EditCLientImg(string url, Client client)
        {
            if (client == null) { return false; }
            client.Img_URL = url;
            UserRepo.UpdateUser(client);
            UserRepo.SaveChanges();
            return true;
        }
    }
}
