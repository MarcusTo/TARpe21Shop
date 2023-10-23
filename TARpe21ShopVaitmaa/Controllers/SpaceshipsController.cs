using Microsoft.AspNetCore.Mvc;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Core.ServiceInterface;
using TARpe21ShopVaitmaa.Data;
using TARpe21ShopVaitmaa.Models;
using TARpe21ShopVaitmaa.Models.Spaceship;

namespace TARpe21ShopVaitmaa.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARpe21ShopVaitmaaContext _context;
        private readonly ISpaceshipsServices _spaceshipsServices;
        public SpaceshipsController
            (
            TARpe21ShopVaitmaaContext context,
            ISpaceshipsServices spaceshipsServices
            )
        {
            _context = context;
            _spaceshipsServices = spaceshipsServices;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderBy(x => x.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower,
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SpaceshipCreateUpdateViewModel spaceship = new SpaceshipCreateUpdateViewModel();
            return View("CreateUpdate", spaceship);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                PassengerCount = vm.PassengerCount,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                MaxSpeedInVaccuum = vm.MaxSpeedInVaccuum,
                BuiltAtDate = vm.BuiltAtDate,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                IsSpaceShipPreviouslyOwned = vm.IsSpaceshipPreviouslyOwned,
                FullTripsCount = vm.FullTripsCount,
                Type = vm.Type,
                EnginePower = vm.EnginePower,
                FuelConsumptionPerDay = vm.FuelConsumptionPerDay,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId,
                }).ToArray()
            };
            var result = await _spaceshipsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipsServices.GetAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipCreateUpdateViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                Description = spaceship.Description,
                PassengerCount = spaceship.PassengerCount,
                CrewCount = spaceship.CrewCount,
                CargoWeight = spaceship.CargoWeight,
                MaxSpeedInVaccuum = spaceship.MaxSpeedInVaccuum,
                BuiltAtDate = spaceship.BuiltAtDate,
                MaidenLaunch = spaceship.MaidenLaunch,
                Manufacturer = spaceship.Manufacturer,
                IsSpaceshipPreviouslyOwned = spaceship.IsSpaceshipPreviouslyOwned,
                FullTripsCount = spaceship.FullTripsCount,
                Type = spaceship.Type,
                EnginePower = spaceship.EnginePower,
                FuelConsumptionPerDay = spaceship.FuelConsumptionPerDay,
                MaintenanceCount = spaceship.MaintenanceCount,
                LastMaintenance = spaceship.LastMaintenance,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };
            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                PassengerCount = vm.PassengerCount,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                MaxSpeedInVaccuum = vm.MaxSpeedInVaccuum,
                BuiltAtDate = vm.BuiltAtDate,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                IsSpaceShipPreviouslyOwned = vm.IsSpaceshipPreviouslyOwned,
                FullTripsCount = vm.FullTripsCount,
                Type = vm.Type,
                EnginePower = vm.EnginePower,
                FuelConsumptionPerDay = vm.FuelConsumptionPerDay,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };
            var result = await _spaceshipsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            var spaceship = await _spaceshipsServices.GetAsync(Id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDetailsViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                Description = spaceship.Description,
                PassengerCount = spaceship.PassengerCount,
                CrewCount = spaceship.CrewCount,
                CargoWeight = spaceship.CargoWeight,
                MaxSpeedInVaccuum = spaceship.MaxSpeedInVaccuum,
                BuiltAtDate = spaceship.BuiltAtDate,
                MaidenLaunch = spaceship.MaidenLaunch,
                Manufacturer = spaceship.Manufacturer,
                IsSpaceshipPreviouslyOwned = spaceship.IsSpaceshipPreviouslyOwned,
                FullTripsCount = spaceship.FullTripsCount,
                Type = spaceship.Type,
                EnginePower = spaceship.EnginePower,
                FuelConsumptionPerDay = spaceship.FuelConsumptionPerDay,
                MaintenanceCount = spaceship.MaintenanceCount,
                LastMaintenance = spaceship.LastMaintenance,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var spaceship = await _spaceshipsServices.GetAsync(Id);

            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipDeleteViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                Description = spaceship.Description,
                PassengerCount = spaceship.PassengerCount,
                CrewCount = spaceship.CrewCount,
                CargoWeight = spaceship.CargoWeight,
                MaxSpeedInVaccuum = spaceship.MaxSpeedInVaccuum,
                BuiltAtDate = spaceship.BuiltAtDate,
                MaidenLaunch = spaceship.MaidenLaunch,
                Manufacturer = spaceship.Manufacturer,
                IsSpaceshipPreviouslyOwned = spaceship.IsSpaceshipPreviouslyOwned,
                FullTripsCount = spaceship.FullTripsCount,
                Type = spaceship.Type,
                EnginePower = spaceship.EnginePower,
                FuelConsumptionPerDay = spaceship.FuelConsumptionPerDay,
                MaintenanceCount = spaceship.MaintenanceCount,
                LastMaintenance = spaceship.LastMaintenance,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid Id)
        {
            var spaceshipId = await _spaceshipsServices.Delete(Id);
            if (spaceshipId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}