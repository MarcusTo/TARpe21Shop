using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Core.ServiceInterface;
using TARpe21ShopVaitmaa.Data;


namespace TARpe21ShopVaitmaa.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly TARpe21ShopVaitmaaContext _context;
        private readonly IFilesServices _files;
        public CarServices(TARpe21ShopVaitmaaContext context, IFilesServices files)
        {
            _context = context;
            _files = files;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.Id = Guid.NewGuid();
            car.CarBrand = dto.CarBrand;
            car.Description = dto.Description;
            car.YearMade = dto.YearMade;
            car.CarPrice = dto.CarPrice;
            car.HorsePower = dto.HorsePower;
            car.TopSpeed = dto.TopSpeed;
            car.CarWeight = dto.CarWeight;
            car.TransmissionType = dto.TransmissionType;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;

        }
        public async Task<Car> Update(CarDto dto)
        {
            Car car = new();

            car.Id = Guid.NewGuid();
            car.CarBrand = dto.CarBrand;
            car.Description = dto.Description;
            car.YearMade = dto.YearMade;
            car.CarPrice = dto.CarPrice;
            car.HorsePower = dto.HorsePower;
            car.TopSpeed = dto.TopSpeed;
            car.CarWeight = dto.CarWeight;
            car.TransmissionType = dto.TransmissionType;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            return carId;
        }
    }
}
