using Microsoft.AspNetCore.Mvc;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Models.Spaceship;

namespace TARpe21ShopVaitmaa.Models.Car
{
    public class CarDeleteViewModel
    {


        public Guid? Id { get; set; } // unique id
        public string CarBrand { get; set; }
        public string Description { get; set; }
        public DateTime YearMade { get; set; } 
        public int HorsePower { get; set; } 
        public int CarPrice { get; set; } 
        public int CarWeight { get; set; }
        public int TopSpeed { get; set; }
        public string TransmissionType { get; set; } //what type of an estate is this

        public List<FileToApiViewM> FileToApiViewModels { get; set; } = new List<FileToApiViewM>(); //file viewmodels
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>(); // images themselves that are added

        public List<FileToApiDto> FileToApiDtos { get; set; } = new List<FileToApiDto>(); //file viewmodels

        //database only properties
        public DateTime CreatedAt { get; set; } //when entry was added to the database
        public DateTime ModifiedAt { get; set; } //when wwas entry modified in the database
    }
}
