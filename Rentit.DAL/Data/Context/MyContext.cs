using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rentit.DAL;

namespace Rentit.DAL
{
    public class MyContext : IdentityDbContext<Account>
    {
      
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UsersData
            var users = new List<Client>
            {  new Client
            {
                Id = 1,
                FName = "John",
                LName = "Doe",
                Email = "john.doe@example.com",
                JoinedDate = DateTime.Parse("2022-01-01"),
                Start_HostingDate = DateTime.Parse("2022-02-01"),
                RoleId = 1, // Assuming RoleId exists
                Img_URL = "user1.jpg"
            },
            new Client
            {
                Id=2,
                FName = "Jane",
                LName = "Smith",
                Email = "jane.smith@example.com",
                JoinedDate = DateTime.Parse("2022-03-15"),
                Start_HostingDate = DateTime.Parse("2022-04-01"),
                RoleId = 2, // Assuming RoleId exists
                Img_URL = "user2.jpg"

            },
            // Add 8 more users
            new Client
            {Id = 3,
                FName = "Alice",
                LName = "Johnson",
                Email = "alice.johnson@example.com",
                JoinedDate = DateTime.Parse("2022-05-20"),
                Start_HostingDate = DateTime.Parse("2022-06-01"),
                RoleId = 2, // Assuming RoleId exists
                Img_URL = "user3.jpg"

            },
            new Client
            {
                Id=4,
                FName = "Bob",
                LName = "Brown",
                Email = "bob.brown@example.com",
                JoinedDate = DateTime.Parse("2022-07-10"),
                Start_HostingDate = DateTime.Parse("2022-08-01"),
                RoleId = 2, // Assuming RoleId exists
                Img_URL = "user4.jpg"

            },
            new Client
            {Id = 5,
                FName = "Eva",
                LName = "Martinez",
                Email = "eva.martinez@example.com",
                JoinedDate = DateTime.Parse("2022-09-15"),
                Start_HostingDate = DateTime.Parse("2022-10-01"),
                RoleId = 2, // Assuming RoleId exists
                Img_URL = "user5.jpg"

            },
            new Client
            {Id=6,
                FName = "Michael",
                LName = "Lee",
                Email = "michael.lee@example.com",
                JoinedDate = DateTime.Parse("2022-11-20"),
                Start_HostingDate = DateTime.Parse("2022-12-01"),
                RoleId = 2, // Assuming RoleId exists
                Img_URL = "user6.jpg"

            },
            new Client
            {Id=7,
                FName = "Sarah",
                LName = "Garcia",
                Email = "sarah.garcia@example.com",
                JoinedDate = DateTime.Parse("2023-01-05"),
                Start_HostingDate = DateTime.Parse("2023-02-01"),
                RoleId = 2, // Assuming RoleId exists
                Img_URL = "user7.jpg"

            },
            new Client
            {
                Id=8,
                FName = "David",
                LName = "Rodriguez",
                Email = "david.rodriguez@example.com",
                JoinedDate = DateTime.Parse("2023-03-10"),
                Start_HostingDate = DateTime.Parse("2023-04-01"),
                RoleId = 2, // Assuming RoleId exists
                Img_URL = "user8.jpg"

            },
            new Client
            {
                Id=9,
                FName = "Emma",
                LName = "Wilson",
                Email = "emma.wilson@example.com",
                JoinedDate = DateTime.Parse("2023-05-15"),
                Start_HostingDate = DateTime.Parse("2023-06-01"),
                RoleId = 2,
                Img_URL = "user9.jpg"


            },
            new Client
            {
                Id=10,
                FName = "James",
                LName = "Taylor",
                Email = "james.taylor@example.com",
                JoinedDate = DateTime.Parse("2023-07-20"),
                Start_HostingDate = DateTime.Parse("2023-08-01"),
                RoleId = 2, // Assuming RoleId exists
                Img_URL = "user10.jpg"

            }
            };
            #endregion
            #region UserRole 
            var userroles = new List<UserRole>
            {
                new UserRole {Id=1,Name="Admin"},
                new UserRole{Id=2,Name="User"}
            };
            #endregion
            #region Governs
            var governs = new List<Governate>
            {
                new Governate { Id = 1, Name = "Cairo" },
            new Governate { Id = 2, Name = "Alexandria" },
            new Governate { Id = 3, Name = "Giza" },
            new Governate { Id = 4, Name = "Shubra El-Kheima" },
            new Governate { Id = 5, Name = "Port Said" },
            new Governate { Id = 6, Name = "Suez" },
            new Governate { Id = 7, Name = "Luxor" },
            new Governate { Id = 8, Name = "Asyut" },
            new Governate { Id = 9, Name = "Aswan" },
            new Governate { Id = 10, Name = "Damietta" },
            };
            #endregion
            #region LocationData
            var locations = new List<Location>
            {
                  new Location
            {
                Id = 1,
                Street = "Main Street",
                City = "Cairo",
                Building_no = 123,
                Building_name = "ABC Building",
                District_name = "Downtown",
                Location_url = "https://maps.example.com/123",
                GovernateId = 1 // Assuming GovernateId exists
            },
            new Location
            {
                Id = 2,
                Street = "First Avenue",
                City = "Alexandria",
                Building_no = 456,
                Building_name = "XYZ Tower",
                District_name = "City Center",
                Location_url = "https://maps.example.com/456",
                GovernateId = 2 // Assuming GovernateId exists
            },
            // Add 8 more locations
            new Location
            {
                Id = 3,
                Street = "Nile Street",
                City = "Luxor",
                Building_no = 789,
                Building_name = "Luxor Plaza",
                District_name = "Riverfront",
                Location_url = "https://maps.example.com/789",
                GovernateId = 3 // Assuming GovernateId exists
            },
            new Location
            {
                Id = 4,
                Street = "Sphinx Avenue",
                City = "Giza",
                Building_no = 101,
                Building_name = "Pyramid Tower",
                District_name = "Tourist Area",
                Location_url = "https://maps.example.com/101",
                GovernateId = 1 // Assuming GovernateId exists
            },
            new Location
            {
                Id = 5,
                Street = "Corniche",
                City = "Alexandria",
                Building_no = 202,
                Building_name = "Seafront Apartments",
                District_name = "Coastal Area",
                Location_url = "https://maps.example.com/202",
                GovernateId = 2 // Assuming GovernateId exists
            },
            new Location
            {
                Id = 6,
                Street = "Pharaohs Road",
                City = "Aswan",
                Building_no = 303,
                Building_name = "Nubian Palace",
                District_name = "Historic Area",
                Location_url = "https://maps.example.com/303",
                GovernateId = 3 // Assuming GovernateId exists
            },
            new Location
            {
                Id = 7,
                Street = "Nile Corniche",
                City = "Cairo",
                Building_no = 404,
                Building_name = "Nile View Towers",
                District_name = "Riverside",
                Location_url = "https://maps.example.com/404",
                GovernateId = 1 // Assuming GovernateId exists
            },
            new Location
            {
                Id = 8,
                Street = "Al-Haram Street",
                City = "Giza",
                Building_no = 505,
                Building_name = "Haram Mall",
                District_name = "Commercial Area",
                Location_url = "https://maps.example.com/505",
                GovernateId = 1 // Assuming GovernateId exists
            },
            new Location
            {
                Id = 9,
                Street = "Marina Road",
                City = "Alexandria",
                Building_no = 606,
                Building_name = "Marina Towers",
                District_name = "Waterfront",
                Location_url = "https://maps.example.com/606",
                GovernateId = 2 // Assuming GovernateId exists
            },
            new Location
            {
                Id = 10,
                Street = "Cleopatra Street",
                City = "Luxor",
                Building_no = 707,
                Building_name = "Cleopatra Palace",
                District_name = "Ancient Area",
                Location_url = "https://maps.example.com/707",
                GovernateId = 3 // Assuming GovernateId exists
            }
            };
            #endregion
            #region PlaceType
            var placetypes = new List<PlaceType>
            {
                new PlaceType{ Id = 1,Name="Room"},
                new PlaceType{ Id = 2,Name="Entire Home"}
            };
            #endregion
            #region PropertyType
            var propertyTypes = new List<PropertyType>
            {
            new PropertyType { Id = 1, Name = "Entire House/Apartment" },
            new PropertyType { Id = 2, Name = "Private Room" },
            new PropertyType { Id = 3, Name = "Shared Room" },
            new PropertyType { Id = 4, Name = "Villa" },
            new PropertyType { Id = 5, Name = "Condo" },
            new PropertyType { Id = 6, Name = "Townhouse" },
            new PropertyType { Id = 7, Name = "Cottage/Cabin" },
            new PropertyType { Id = 8, Name = "Bungalow" },
            new PropertyType { Id = 9, Name = "Chalet" },
            new PropertyType { Id = 10, Name = "Farm stay" },
            new PropertyType { Id = 11, Name = "Boat/Yacht" },
            new PropertyType { Id = 12, Name = "Treehouse" },
            new PropertyType { Id = 13, Name = "Yurt" },
            new PropertyType { Id = 14, Name = "Tent/Campsite" },
            new PropertyType { Id = 15, Name = "Igloo" }
            };
            #endregion
            #region Property sates 
            var propertyStates = new List<PropertyStates>
            {
                new PropertyStates {Id=1,Name="Available"},
                new PropertyStates {Id=2,Name="Under maintainance"},
                new PropertyStates {Id=3,Name="Booked"},
                new PropertyStates {Id=4,Name="Unavailable"}
            };
            #endregion
            #region Property data
            var properties = new List<Propertyy>
            {
                  new Propertyy
    {
        Id = 1,
        Property_Name = "Cozy Apartment in Downtown",
        Nighly_Price = 100,
        Description = "A comfortable apartment located in the heart of the city.",
        Nums_Guests = 2,
        Nums_Beds = 1,
        Nums_Bathrooms = 1,
        Nums_Bedrooms = 1,
        Nums_Web_visitors = 0,
        Loc_id = 1, // Assuming Location Id exists
        PlaceType_ID = 1, // Assuming PlaceType Id exists
        PropetyTypeId = 1, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 3 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 2,
        Property_Name = "Spacious Villa with Pool",
        Nighly_Price = 300,
        Description = "A luxurious villa with a private pool and stunning views.",
        Nums_Guests = 6,
        Nums_Beds = 3,
        Nums_Bathrooms = 2,
        Nums_Bedrooms = 3,
        Nums_Web_visitors = 0,
        Loc_id = 2, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 2, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 2 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 3,
        Property_Name = "Beachfront Cottage",
        Nighly_Price = 150,
        Description = "A charming cottage located right on the beach, perfect for a romantic getaway.",
        Nums_Guests = 4,
        Nums_Beds = 2,
        Nums_Bathrooms = 1,
        Nums_Bedrooms = 1,
        Nums_Web_visitors = 0,
        Loc_id = 3, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 3, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 3 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 4,
        Property_Name = "Rustic Cabin in the Woods",
        Nighly_Price = 120,
        Description = "A cozy cabin nestled in the forest, perfect for nature lovers.",
        Nums_Guests = 3,
        Nums_Beds = 2,
        Nums_Bathrooms = 1,
        Nums_Bedrooms = 1,
        Nums_Web_visitors = 0,
        Loc_id = 4, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 4, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 4 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 5,
        Property_Name = "Mountain Chalet with Hot Tub",
        Nighly_Price = 250,
        Description = "A charming chalet with stunning mountain views and a relaxing hot tub.",
        Nums_Guests = 8,
        Nums_Beds = 4,
        Nums_Bathrooms = 2,
        Nums_Bedrooms = 3,
        Nums_Web_visitors = 0,
        Loc_id = 5, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 5, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 5 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 6,
        Property_Name = "Historic Townhouse in City Center",
        Nighly_Price = 200,
        Description = "An elegant townhouse located in the historic district, within walking distance to major attractions.",
        Nums_Guests = 4,
        Nums_Beds = 2,
        Nums_Bathrooms = 2,
        Nums_Bedrooms = 2,
        Nums_Web_visitors = 0,
        Loc_id = 6, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 6, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 5 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 7,
        Property_Name = "Luxury Penthouse with Panoramic Views",
        Nighly_Price = 500,
        Description = "A luxurious penthouse offering breathtaking views of the city skyline.",
        Nums_Guests = 2,
        Nums_Beds = 1,
        Nums_Bathrooms = 1,
        Nums_Bedrooms = 1,
        Nums_Web_visitors = 0,
        Loc_id = 7, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 7, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 7 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 8,
        Property_Name = "Sunny Beach House with Pool",
        Nighly_Price = 350,
        Description = "A beautiful beach house with a private pool, perfect for a relaxing getaway.",
        Nums_Guests = 6,
        Nums_Beds = 3,
        Nums_Bathrooms = 2,
        Nums_Bedrooms = 3,
        Nums_Web_visitors = 0,
        Loc_id = 8, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 8, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 8 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 9,
        Property_Name = "Riverside Cabin with Fishing Dock",
        Nighly_Price = 180,
        Description = "A cozy cabin by the river with a private fishing dock, perfect for outdoor enthusiasts.",
        Nums_Guests = 4,
        Nums_Beds = 2,
        Nums_Bathrooms = 1,
        Nums_Bedrooms = 1,
        Nums_Web_visitors = 0,
        Loc_id = 9, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 9, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 9 // Assuming Host Id exists
    },
    new Propertyy
    {
        Id = 10,
        Property_Name = "Eco-Friendly Treehouse Retreat",
        Nighly_Price = 200,
        Description = "A unique eco-friendly treehouse retreat surrounded by nature, perfect for a peaceful escape.",
        Nums_Guests = 2,
        Nums_Beds = 1,
        Nums_Bathrooms = 1,
        Nums_Bedrooms = 1,
        Nums_Web_visitors = 0,
        Loc_id = 10, // Assuming Location Id exists
        PlaceType_ID = 2, // Assuming PlaceType Id exists
        PropetyTypeId = 10, // Assuming PropertyType Id exists
        StateId = 1, // Assuming PropertyStates Id exists
        HostId = 10 // Assuming Host Id exists
    }

            };
            #endregion
            #region Images Insrances 
            var images = new List<Image>
            {
                new Image { Id = 1, Img_URL = "https://img.freepik.com/free-photo/3d-house-model-with-modern-architecture_23-2151004065.jpg?t=st=1712117397~exp=1712120997~hmac=1a2ad4c7342725d276b70bee4e75dd551f744052cac67a255d150de79fc61745&w=900", Img_order = 1, PropertyId = 1 },
                new Image { Id = 2, Img_URL = "https://img.freepik.com/free-photo/front-view-front-door-with-white-wall-plants_23-2149360608.jpg?t=st=1712117418~exp=1712121018~hmac=61d37274b4944fec15d6f5ed1eb4f004e4772dd03248df0c058e3e2f651c1f9a&w=740", Img_order = 2, PropertyId = 1 },
                new Image { Id = 3, Img_URL = "https://img.freepik.com/free-photo/mosque-pictures-moroccan-wall-pattern_1203-5080.jpg?t=st=1712117254~exp=1712120854~hmac=3f3d33979735c2b8d03323cf139d35d7cc2c2919c8eaa1c2b1272923e1a1c142&w=740", Img_order =2, PropertyId = 2 },
                new Image { Id = 4, Img_URL = "https://img.freepik.com/free-vector/hand-sketch-art-decor-inspired-large-floral-arrangement_1409-4511.jpg?w=740&t=st=1711924304~exp=1711924904~hmac=198bbde6e9b3da518d3fe0904717c37d2bb559fb797e03b42663c1e061e9722f", Img_order = 1, PropertyId = 2 },
                new Image { Id = 5, Img_URL = "https://img.freepik.com/free-photo/luxury-pool-villa-spectacular-contemporary-design-digital-art-real-estate-home-house-property-ge_1258-150749.jpg?t=st=1712117445~exp=1712121045~hmac=429a6408e64495a6d543152f5243d1d29d2d7651937d7c7c34802828d94a8a9e&w=900", Img_order = 1, PropertyId = 3 },
                new Image { Id = 6, Img_URL = "https://img.freepik.com/free-photo/road-city_1417-1426.jpg?t=st=1712117465~exp=1712121065~hmac=303d36a852079b1948e617f509dfce9423bc4ba52da3d484dadb5dacbe7225d4&w=900", Img_order = 2, PropertyId = 3 },
                new Image { Id = 7, Img_URL = "https://img.freepik.com/free-photo/3d-rendering-house-model_23-2150799723.jpg?t=st=1712117482~exp=1712121082~hmac=8291103bc5178bba4099f63c14a648b345ef908c1a66bd2914378f534b777fca&w=740", Img_order = 1, PropertyId = 4 },
                new Image { Id = 8, Img_URL = "https://img.freepik.com/free-photo/3d-rendering-house-model_23-2150799687.jpg?t=st=1712117500~exp=1712121100~hmac=7584209dfe4ab0fa004cb16a25bf17619bd9fdc0cfad245928ac6b199fd82cc0&w=740", Img_order = 2, PropertyId = 4 },
                new Image { Id = 9, Img_URL = "https://img.freepik.com/free-photo/3d-rendering-house-model_23-2150799725.jpg?t=st=1712117522~exp=1712121122~hmac=2d8432ff5656294aff471f60925a6724959e51b3ff96e594afa6827b8916cbc8&w=740", Img_order = 1, PropertyId = 5 },
                new Image { Id = 10, Img_URL = "https://img.freepik.com/free-photo/abandoned-closed-wooden-church-forest-countryside_181624-798.jpg?t=st=1712117536~exp=1712121136~hmac=f022c3c067bc808c2fa623e2fdb1accb008d7d2c0859d66a3dbe1a347701fe41&w=740", Img_order = 2, PropertyId = 5 },
                new Image { Id = 11, Img_URL = "https://img.freepik.com/free-photo/3d-rendering-house-model_23-2150799703.jpg?t=st=1712117559~exp=1712121159~hmac=614b9fba699ee26e9ba722f3e905473c349c80fa686151ebd3a11b181b7406a3&w=360", Img_order = 1, PropertyId = 6 },
                new Image { Id = 12, Img_URL = "https://img.freepik.com/free-photo/vertical-shot-modern-apartments-daytime_181624-13625.jpg?t=st=1712117582~exp=1712121182~hmac=7f04d601a4ffdb3a9fed51e6e517752e4cbc903506b422a15c8146e9cea14d5e&w=740", Img_order = 2, PropertyId = 6 },
                new Image { Id = 13, Img_URL = "https://img.freepik.com/free-photo/promenade-canal-dubai-marina-with-luxury-skyscrapers-around-united-arab-emirates_231208-7556.jpg?t=st=1712117605~exp=1712121205~hmac=83fec7ef9d2360d0ab2e3354604fadbcf83d9fea4073a0fd81f4429988fe7a85&w=740", Img_order = 3, PropertyId = 7 },
                new Image { Id = 14, Img_URL = "https://img.freepik.com/free-photo/analog-landscape-city-with-buildings_23-2149661457.jpg?t=st=1712117640~exp=1712121240~hmac=d5bafc7058c817487e4cc8aef8bc218d30547889a3b7253402b253c13c44d04c&w=740", Img_order = 4, PropertyId = 7 },
                new Image { Id = 15, Img_URL = "https://img.freepik.com/free-photo/3d-house-model-with-modern-architecture_23-2151004054.jpg?t=st=1712117688~exp=1712121288~hmac=0a0c307151447c7303579f8a6442870ec814f6ecd1e6c5638638a58cf823c982&w=900", Img_order = 1, PropertyId = 8 },
                new Image { Id = 16, Img_URL = "https://img.freepik.com/free-photo/contemporary-house-interior-design_23-2151050939.jpg?t=st=1712117704~exp=1712121304~hmac=e0f42042c3020b895162605ec418bba3b509993be192a4b1062ecad1900a5b1f&w=900", Img_order = 2, PropertyId = 8 },
            };
            #endregion
            #region Attributes 
            var attributes = new List<Attributes>
            {
            new Attributes { Id = 1, Name = "WiFi", Icon_Url = "icon1.jpg" },
            new Attributes { Id = 2, Name = "Washer", Icon_Url = "icon2.jpg" },
            new Attributes { Id = 3, Name = "Extra pillows and blankets", Icon_Url = "icon3.jpg" },
            new Attributes { Id = 4, Name = "Iron", Icon_Url = "icon4.jpg" },
            new Attributes { Id = 5, Name = "TV", Icon_Url = "icon5.jpg" },
            new Attributes { Id = 6, Name = "Air conditioning", Icon_Url = "icon6.jpg" },
            new Attributes { Id = 7, Name = "Heating", Icon_Url = "icon7.jpg" },
            new Attributes { Id = 8, Name = "Carbon monoxide alarm", Icon_Url = "icon8.jpg" },
            new Attributes { Id = 9, Name = "kitchen essentials", Icon_Url = "icon9.jpg" },
            new Attributes { Id = 10,Name = "Outdoor dining area", Icon_Url = "icon10.jpg" },
            new Attributes { Id = 11,Name="Outdoor dining area", Icon_Url="icon11.jpg"},
            new Attributes { Id = 12,Name="BBQ grill" , Icon_Url="icon12.jpg"},
            new Attributes { Id = 13,Name="Security cameras on property",Icon_Url="icon13.jpg"},
            new Attributes { Id = 14,Name="Smoke alarm",Icon_Url="icon14.jpg"},
            new Attributes { Id = 15,Name="Free parking on premises",Icon_Url="icon15.jpg" }
            };
            #endregion
            #region Request State
            var requestStates = new List<RequestState> 
                { 
                new RequestState { Id = 1,Status="Pending"},
                new RequestState { Id = 2,Status="Accepted"},
                new RequestState { Id = 3,Status="Refused"}
                };
            #endregion
            modelBuilder.Entity<UserRole>().HasData(userroles);
            modelBuilder.Entity<Client>().HasData(users);
            modelBuilder.Entity<Governate>().HasData(governs);
            modelBuilder.Entity<Location>().HasData(locations);
            modelBuilder.Entity<PlaceType>().HasData(placetypes);
            modelBuilder.Entity<PropertyType>().HasData(propertyTypes);
            modelBuilder.Entity<PropertyStates>().HasData(propertyStates);
            modelBuilder.Entity<Propertyy>().HasData(properties);
            modelBuilder.Entity<Image>().HasData(images);
            modelBuilder.Entity<Attributes>().HasData(attributes);  
            modelBuilder.Entity<RequestState>().HasData(requestStates); 

            modelBuilder.Entity<RequestRent>()
                .HasOne(rr => rr.User)
                .WithMany(u => u.RequestRents)
                .HasForeignKey(rr => rr.UserID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RequestRent>()
                .HasOne(rr => rr.Property)
                .WithMany(u => u.RequestRents)
                .HasForeignKey(rr => rr.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<RequestRent>()
            //    .HasOne(rr => rr.Host)
            //    .WithMany(u=>u.RequestRents)
            //    .HasForeignKey(rr=>rr.HostID)
            //    .OnDelete(DeleteBehavior.NoAction); 
            modelBuilder.Entity<RequestRent>()
                .HasOne(rr => rr.Request_state_Admin)
                .WithMany()
                .HasForeignKey(s=>s.Request_StateID_Admin)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RequestRent>()
                .HasOne(rr => rr.Request_state_Host)
                .WithMany()
                .HasForeignKey(s => s.Request_StateID_Host)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Client> Users => Set<Client>();
        public DbSet<UserRole> Roles => Set<UserRole>();
        public DbSet<Propertyy> Properties => Set<Propertyy>();
        public DbSet<Governate> Governs => Set<Governate>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<PlaceType> PlaceTypes => Set<PlaceType>();
        public DbSet<PropertyType> PropertyTypes => Set<PropertyType>();
        public DbSet<PropertyStates> PropertyStates => Set<PropertyStates>();
        public DbSet<Image> Images => Set<Image>();
        public DbSet<Attributes> Attributes => Set<Attributes>();
        public DbSet<RequestRent> RequestRents => Set<RequestRent>();
        public DbSet<RequestState> RequestStates => Set<RequestState>();
        public DbSet<RequestHost> RequestHosts => Set<RequestHost>();
        public DbSet<ImgesForRequest> ImgesForRequests => Set<ImgesForRequest>();
        public DbSet<UserReview> UserReviews => Set<UserReview>();
        public DbSet<Favourite> Favourites => Set<Favourite>();
    }
}
