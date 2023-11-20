using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe21ShopVaitmaa.ApplicationServices.Services;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Core.ServiceInterface;
using TARpe21ShopVaitmaa.Data;
using TARpe21ShopVaitmaa.Models.Car;
using TARpe21ShopVaitmaa.Models.Spaceship;

namespace TARpe21ShopVaitmaa.Controllers
{
    public class CarController : Controller
    {
        private readonly TARpe21ShopVaitmaaContext _context;
        private readonly ICarServices _carService;
        private readonly IFilesServices _filesServices;
        public CarController(ICarServices carService, TARpe21ShopVaitmaaContext context, IFilesServices filesServices)
        {
            _carService = carService;
            _context = context;
            _filesServices = filesServices;
        }
        public async Task<IActionResult> Index()
        {
            var result = _context.Cars
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new CarIndexViewModel
                {

                    Id = x.Id,
                    CarBrand = x.CarBrand,
                    Description = x.Description,
                    YearMade = x.YearMade,
                    CarPrice = x.CarPrice,
                    HorsePower = x.HorsePower,
                    TopSpeed = x.TopSpeed,
                    CarWeight = x.CarWeight,
                    TransmissionType = x.TransmissionType,
                });
                    
            return View(result);

        }
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new ();
             return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = Guid.NewGuid(),
                CarBrand = vm.CarBrand,
                Description = vm.Description,
                YearMade = vm.YearMade,
                CarPrice = vm.CarPrice,
                HorsePower = vm.HorsePower,
                TopSpeed = vm.TopSpeed,
                CarWeight = vm.CarWeight,
                TransmissionType = vm.TransmissionType,
                Files = vm.Files,
                FileToApiDtos = vm.FileToApiViewModels
                .Select(x => new FileToApiDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carService.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carService.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewM
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();
            
            vm.Id = car.Id;
            vm.CarBrand = car.CarBrand;
            vm.Description = car.Description;
            vm.YearMade = car.YearMade;
            vm.CarPrice = car.CarPrice;
            vm.HorsePower = car.HorsePower;
            vm.TopSpeed = car.TopSpeed;
            vm.CarWeight = car.CarWeight;
            vm.TransmissionType = car.TransmissionType;

          
            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = (Guid)vm.Id,
                CarBrand = vm.CarBrand,
                Description = vm.Description,
                YearMade = vm.YearMade,
                CarPrice = vm.CarPrice,
                HorsePower = vm.HorsePower,
                TopSpeed = vm.TopSpeed,
                CarWeight = vm.CarWeight,
                TransmissionType = vm.TransmissionType,
                Files = vm.Files,
                FileToApiDtos = vm.FileToApiViewModels
                .Select(x => new FileToApiDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carService.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carService.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewM
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new CarDetailsViewModel();

            vm.Id = car.Id;
            vm.CarBrand = car.CarBrand;
            vm.Description = car.Description;
            vm.YearMade = car.YearMade;
            vm.CarPrice = car.CarPrice;
            vm.HorsePower = car.HorsePower;
            vm.TopSpeed = car.TopSpeed;
            vm.CarWeight = car.CarWeight;
            vm.TransmissionType = car.TransmissionType;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.FileToApiViewModels.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carService.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel();

            vm.Id = car.Id;
            vm.CarBrand = car.CarBrand;
            vm.Description = car.Description;
            vm.YearMade = car.YearMade;
            vm.CarPrice = car.CarPrice;
            vm.HorsePower = car.HorsePower;
            vm.TopSpeed = car.TopSpeed;
            vm.CarWeight = car.CarWeight;
            vm.TransmissionType = car.TransmissionType;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var car = await _carService.Delete(id);
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(FileToApiViewM vm)
        {
            var dto = new FileToApiDto()
            {
                Id = vm.ImageId
            };
            var image = await _filesServices.RemoveImageFromApi(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
