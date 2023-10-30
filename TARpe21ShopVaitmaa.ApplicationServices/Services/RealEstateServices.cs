using Microsoft.EntityFrameworkCore;
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
        private readonly IFilesServices _filesServices;
        public RealEstatesServices
            (
            TARpe21ShopVaitmaaContext context,
            IFilesServices fileServices
            )
        {
            _context = context;
            _filesServices = fileServices;
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
            realEstate.Type = dto.Type;
            realEstate.IsPropertyNewDevelopment = dto.IsPropertyNewDevelopment;
            realEstate.IsPropertySold = dto.IsPropertySold;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, realEstate);

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();
            return realEstate;
        }
        public async Task<RealEstate> Delete(Guid id)
        {
            var realEstateId = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.RealEstates.Remove(realEstateId);
            await _context.SaveChangesAsync();
            return realEstateId;
        }
        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            var domain = new RealEstate()
            {
                Id = Guid.NewGuid(),
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                County = dto.County,
                PostalCode = dto.PostalCode,
                PhoneNumber = dto.PhoneNumber,
                FaxNumber = dto.FaxNumber,
                ListingDescription = dto.ListingDescription,
                SquareMeters = dto.SquareMeters,
                BuildDate = dto.BuildDate,
                Price = dto.Price,
                RoomCount = dto.RoomCount,
                EstateFloor = dto.EstateFloor,
                Bathrooms = dto.Bathrooms,
                Bedrooms = dto.Bedrooms,
                DoesHaveParkingSpace = dto.DoesHaveParkingSpace,
                DoesHavePowerGridConnection = dto.DoesHavePowerGridConnection,
                DoesHaveWaterGridConnection = dto.DoesHaveWaterGridConnection,
                Type = dto.Type,
                IsPropertyNewDevelopment = dto.IsPropertyNewDevelopment,
                IsPropertySold = dto.IsPropertySold,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            _context.RealEstates.Update(domain)
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<RealEstate>GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        
    }
}