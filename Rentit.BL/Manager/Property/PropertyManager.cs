using Rentit.BL.Dtos;
using Rentit.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL
{
    public class PropertyManager : IPropertyManager
    {
        private readonly IPropertyRepo propertyRepo;
        private readonly IRequestHostRepo requestHostRepo;

        public PropertyManager(IPropertyRepo _propertyRepo , IRequestHostRepo _requestHostRepo)
        { this.propertyRepo = _propertyRepo; 
          this.requestHostRepo = _requestHostRepo;
        }
        public bool Add(int requestID)
        {
            RequestHost? propertyAdd = requestHostRepo.GetByID(requestID);
            if (propertyAdd?.Request_StateID != 2)
            {
                return false;  
            }
            Location loc = new()
            {
                Street = propertyAdd.Street,
                Building_name = propertyAdd.Building_name,
                Building_no = propertyAdd.Building_no,
                City = propertyAdd.City,
                District_name = propertyAdd.District_name,
                Location_url = propertyAdd.Location_url,
                GovernateId = propertyAdd.GovernateId
            };
            propertyRepo.AddLocation(loc);
            propertyRepo.SaveChanges();
            Propertyy property = new()
            {
                Property_Name = propertyAdd.Property_Name,
                Description = propertyAdd.Description,
                Nighly_Price = propertyAdd.Nighly_Price,
                PlaceType_ID = propertyAdd.PlaceType_ID,
                Nums_Bathrooms = propertyAdd.Nums_Bathrooms,
                Nums_Bedrooms = propertyAdd.Nums_Bedrooms,
                Nums_Beds = propertyAdd.Nums_Beds,
                Nums_Guests = propertyAdd.Nums_Guests,
                PropetyTypeId = propertyAdd.PropetyTypeId,
                StateId = 1,
                HostId = propertyAdd.UserID,
                Loc_id = loc.Id,
            };
           
            propertyRepo.Add(property);
            propertyRepo.SaveChanges();
            foreach (var item in propertyAdd.Attributes_requests)
            {
                property.Attributes_property.Add(item);
                propertyRepo.SaveChanges();

            }
            foreach (var item in propertyAdd.Imgs)
            {
                Image Images = new Image()
                {
                    Img_URL = item.Img_URL,
                    Img_order = item.Img_order,
                    PropertyId = property.Id
                };
                property.Property_imgs.Add(Images); 
                propertyRepo.SaveChanges(); 
            }
            return true;
        }
        public bool Delete(int id)
        {
           Propertyy? property = propertyRepo.GetByID(id);
            if(property == null)    return false;   
            propertyRepo.Delete(property);
            propertyRepo.SaveChanges();
            return true;    
        }
        public IEnumerable<ListPropertyReadDto> GetAll()
        {
            DateTime TodayTime = DateTime.Now;  
            IEnumerable<Propertyy> PropertiesFromDb = propertyRepo.GetAll();
            foreach(Propertyy property in PropertiesFromDb)     
            {
                foreach(RequestRent request in property.RequestRents)
                {
                    if(request.Checkout_date <  TodayTime)
                    {
                        property.StateId= 1;    
                    }

                }
            }

            return PropertiesFromDb.Select(p => new ListPropertyReadDto
            {
                Id = p.Id,
                Property_Name = p.Property_Name,
                Nighly_Price = p.Nighly_Price,
                Description = p.Description,
                Nums_Guests = p.Nums_Guests,
                Nums_Bathrooms = p.Nums_Bathrooms,
                Nums_Beds = p.Nums_Bedrooms,
                Nums_Bedrooms = p.Nums_Bedrooms,
                Nums_Web_visitors = p.Nums_Web_visitors,
                DistrictName = p.Location.District_name,
                governate = p.Location.Governate.Name,
                Property_Type = p.Property_Type.Name,
                State = p.Property_States.Name,
                image = p.Property_imgs.OrderBy(i=>i.Img_order).Select(i=>i.Img_URL).FirstOrDefault(),
                attributes = p.Attributes_property.Select(a => new AttributesChildDto
                { Id = a.Id, Name = a.Name, Icon_Url = a.Icon_Url }).ToList()
            }) ;
        }
        public ListPropertyReadDto? GetById(int id)
        {
            Propertyy? p = propertyRepo.GetByID(id);
            if (p == null) return null;
            return new ListPropertyReadDto
            {
                Id = p.Id,
                Property_Name = p.Property_Name,
                Nighly_Price = p.Nighly_Price,
                Description = p.Description,
                Nums_Guests = p.Nums_Guests,
                Nums_Bathrooms = p.Nums_Bathrooms,
                Nums_Beds = p.Nums_Bedrooms,
                Nums_Bedrooms = p.Nums_Bedrooms,
                Nums_Web_visitors = p.Nums_Web_visitors,
                Property_Type = p.Property_Type.Name,
            };
        }

        public PropertyReadDetailsDto? GetPropertyDetails(int id)
        {
            DateTime TodayTime = DateTime.Now;
            Propertyy? property = propertyRepo.GetPropertyWithImagesAndAttributs(id);
                foreach (RequestRent request in property.RequestRents)
                {
                    if (request.Checkout_date < TodayTime)
                    {
                        property.StateId = 1;
                    }
                }
            int x = property.Nums_Web_visitors++;
            propertyRepo.Update(property);
            propertyRepo.SaveChanges(); 
            if (property == null) return null;
            LocationReadDto loc = new()
            {
                Id = property.Location.Id,
                Building_name=property.Location.Building_name,  
                Building_no=property.Location.Building_no,  
                Street=property.Location.Street,
                City=property.Location.City,    
                Location_url=property.Location.Location_url,    
                District_name=property.Location.District_name,
                governate=property.Location.Governate.Name,
            };
            return new PropertyReadDetailsDto
            {
                Id = id,
                Property_Name = property.Property_Name,
                Nighly_Price = property.Nighly_Price,
                Description = property.Description,
                Nums_Bathrooms = property.Nums_Bathrooms,
                Nums_Bedrooms = property.Nums_Bedrooms,
                Nums_Beds = property.Nums_Beds,
                Nums_Guests = property.Nums_Guests,
                Nums_Web_visitors = x,
                placeType = property.Place_Type.Name,
                Property_Type = property.Property_Type.Name,
                State = property.Property_States.Name,
                HostId = property.User.Id,
                HostName = $"{property.User.FName} {property.User.LName}",
                Host_image = property.User.Img_URL,
                location = loc,
                Images = property.Property_imgs.Select(i => new ImageChildDto
                {
                    Id = i.Id,
                    Img_order = i.Img_order,
                    Img_URL = i.Img_URL
                }).ToList(),

                attributes = property.Attributes_property.Select(a => new AttributesChildDto
                { Id = a.Id, Name = a.Name, Icon_Url = a.Icon_Url }).ToList(),

                UserReviews = property.UserReviews.Select(r => new ReviewReadDto
                {
                    Client_Name = $"{r.User.FName} {r.User.LName}",
                    Review = r.Comment,
                    Img_Url = r.User.Img_URL
                }).ToList()
            };
        }


        public bool Update(PropertyUpdateDto propertyUpdate)
        {
           Propertyy? property = propertyRepo.GetByID(propertyUpdate.Id);   
            if (property == null) return false; 
            property.Property_Name = propertyUpdate.Property_Name;  
            property.Nighly_Price= propertyUpdate.Nighly_Price; 
            property.Description = propertyUpdate.Description;  
            property.Nums_Beds = propertyUpdate.Nums_Beds;  
            property.Nums_Bathrooms= propertyUpdate.Nums_Bathrooms; 
            property.Nums_Bedrooms = propertyUpdate.Nums_Bedrooms;  
            property.Nums_Guests = propertyUpdate.Nums_Guests;  
            property.PlaceType_ID = propertyUpdate.PlaceType_ID;    
            property.PropetyTypeId = propertyUpdate.PropetyTypeId;  
            property.StateId = propertyUpdate.StateId;

            propertyRepo.Update(property);
            propertyRepo.SaveChanges(); 
            return true;
        }

        public void AddReview(ReviewAddDto Review, int propertyid, int userid)
        {
            UserReview userReview = new UserReview()
            {
                Comment = Review.Review,
                Review_date = DateTime.Now, 
                PropertyID = propertyid,    
                Userid = userid           
            };
            propertyRepo.AddReview(userReview);
            propertyRepo.SaveChanges();
        }

    }
}
