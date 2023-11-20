using Microsoft.AspNetCore.Mvc;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Models.Spaceship;

namespace TARpe21ShopVaitmaa.Models.Car
{
    public class CarCreateUpdateViewModel
    {


        public Guid? Id { get; set; } // unique id
        public string CarBrand { get; set; }
        public string Description { get; set; }
        public DateTime YearMade { get; set; } //city where realestate is, city is optional incase the 
        public int HorsePower { get; set; } //postal code for the address
        public int CarPrice { get; set; } // to call about the property
        public int CarWeight { get; set; }

        public int TopSpeed { get; set; }
        public string TransmissionType { get; set; } //what type of an estate is this

        public List<FileToApiViewM> FileToApiViewModels { get; set; } = new List<FileToApiViewM>(); //file viewmodels

        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>(); // images themselves that are added

        //database only properties
        public DateTime CreatedAt { get; set; } //when entry was added to the database
        public DateTime ModifiedAt { get; set; } //when wwas entry modified in the database
    }
}

