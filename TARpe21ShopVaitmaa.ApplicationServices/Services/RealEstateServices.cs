using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Core.ServiceInterface;
using TARpe21ShopVaitmaa.Data;

namespace TARpe21ShopVaitmaa.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstatesServices
    {
        private readonly TARpe21ShopVaitmaaContext _context;
        public RealEstatesServices
            (
            TARpe21ShopVaitmaaContext context
            )
        {
            _context = context;
        }

        public async Task<RealEstate> GetAsync()
        {
            //var result = await _context.RealEstates
            //    .FirstOrDefaultAsync(x => x.Id == id);
            return null;
        }
        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.City = dto.City;
            realEstate.Country = dto.Country;
            realEstate.County = dto.County;
            realEstate.PostalCode = dto.PostalCode;
            realEstate.PhoneNumber = dto.PhoneNumber;
            realEstate.FaxNumber = dto.FaxNumber;
            realEstate.ListingDescription = dto.ListingDescription;
            realEstate.SquareMeters = dto.SquareMeters;
            realEstate.BuildDate = dto.BuildDate;
            realEstate.Price = dto.Price;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.EstateFloor = dto.EstateFloor;
            realEstate.Bathrooms = dto.Bathrooms;
            realEstate.Bedrooms = dto.Bedrooms;
            realEstate.DoesHaveParkingSpace = dto.DoesHaveParkingSpace;
            realEstate.DoesHavePowerGridConnection = dto.DoesHavePowerGridConnection;
            realEstate.DoesHaveWaterGridConnection = dto.DoesHaveWaterGridConnection;
            realEstate.EstateType = (Core.Domain.EstateType)dto.EstateType;
            realEstate.IsPropertyNewDevelopment = dto.IsPropertyNewDevelopment;
            realEstate.IsPropertySold = dto.IsPropertySold;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();
            return realEstate;
        }
    }
}