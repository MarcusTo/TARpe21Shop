using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Core.ServiceInterface;
using TARpe21ShopVaitmaa.ApplicationServices.Services;
using TARpe21ShopVaitmaa.Data.Migrations;
using Xunit;

namespace TARpe21ShopVaitmaa.CarTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyCars_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            CarDto car = new CarDto();

            car.Id = Guid.Parse(guid);
            car.CarBrand = "Test name";
            car.Description = "Car Description";
            car.YearMade = 2015;
            car.CarPrice = 29000;
            car.HorsePower = 200;
            car.TopSpeed = 180;
            car.CarWeight = 1500;
            car.TransmissionType = "Automatic";
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            var result = await Svc<ICarServices>().Create(car);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Should_DeleteByIdCar_WhenDeleteCar()
        {
            CarDto dto = MockCarData();
            var Car = await Svc<ICarServices>().Create(dto);

            var result = await Svc<ICarServices>().Delete((Guid)Car.Id);

            Assert.Equal(result, Car);
        }
        [Fact]
        public async Task Should_UpdateCar_WhenUpdateData()
        {

            var guid = new Guid("468da5b9-f1d7-4478-87b8-8b0888eb0da1");


            Car car = new Car();
            CarDto dto = MockCarData();

            car.Id = Guid.Parse("468da5b9-f1d7-4478-87b8-8b0888eb0da1");
            car.CarBrand = "Test name";
            car.Description = "Car Description";
            car.YearMade = 2015;
            car.CarPrice = 29000;
            car.HorsePower = 200;
            car.TopSpeed = 180;
            car.CarWeight = 1500;
            car.TransmissionType = "Automatic";
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            await Svc<ICarServices>().Update(dto);

            Assert.Equal(car.Id, guid);
            Assert.DoesNotMatch(car.CarBrand, dto.CarBrand);
            Assert.NotEqual(car.Description, dto.Description);
        }

        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                CarBrand = "Testname",
                Description = "Test description",
                YearMade = 2015,
                CarPrice = 29000,
                HorsePower = 200,
                TopSpeed = 180,
                CarWeight = 1500,
                TransmissionType = "Automatic",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return car;

        }
        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
        {
            CarDto dto = MockCarData();
            var Car = await Svc<ICarServices>().Create(dto);

            CarDto NullUpdate = MockNotUptadeCar();
            var result = await Svc<ICarServices>().Update(NullUpdate);

            var NullID = NullUpdate.Id;

            Assert.True(result.Id != NullID);
        }
        private CarDto MockNotUptadeCar()
        {
            CarDto NotCar = new()
            {
                CarBrand = "Testname",
                Description = "Test description",
                YearMade = 2015,
                CarPrice = 29000,
                HorsePower = 200,
                TopSpeed = 180,
                CarWeight = 1500,
                TransmissionType = "Automatic",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return NotCar;

        }
    }
}
