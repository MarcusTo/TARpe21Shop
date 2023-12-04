using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Core.ServiceInterface;
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
    }
}
