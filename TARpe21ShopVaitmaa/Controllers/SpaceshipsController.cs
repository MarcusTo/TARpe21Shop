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
                .Select(x => new SpaceShipIndexViewModel
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
        public IActionResult Add()
        {
            return View("Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipEditViewModel vm)
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
                IsSpaceShipPreviouslyOwned  = vm.IsSpaceShipPreviouslyOwned ,
                FullTripsCount = vm.FullTripsCount,
                Type = vm.Type,
                EnginePower = vm.EnginePower,
                FuelConsumptionPerDay = vm.FuelConsumptionPerDay,
                MaintenanceCount= vm.MaintenanceCount,
                LastMaintenance= vm.LastMaintenance,
                CreatedAt= vm.CreatedAt,
                ModifiedAt= vm.ModifiedAt
            };
            var result = await _spaceshipsServices.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipsServices.GetUpdate(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipEditViewModel()
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
                IsSpaceShipPreviouslyOwned = spaceship.IsSpaceShipPreviouslyOwned,
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
        public async Task<IActionResult> Update(SpaceshipEditViewModel vm)
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
                IsSpaceShipPreviouslyOwned = vm.IsSpaceShipPreviouslyOwned,
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
    }

}

