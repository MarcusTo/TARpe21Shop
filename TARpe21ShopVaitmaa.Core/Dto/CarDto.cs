using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopVaitmaa.Core.Dto
{
    public class CarDto
    {
        public Guid Id { get; set; } // unique id
        public string CarBrand { get; set; }
        public string Description { get; set; }
        public int YearMade { get; set; } //city where realestate is, city is optional incase the 
        public int HorsePower { get; set; } //postal code for the address
        public int CarPrice { get; set; } //phonenumber to call about the property
        public int CarWeight { get; set; }

        public int TopSpeed { get; set; }
        public string TransmissionType { get; set; } //what type of an estate is this
        public List<IFormFile> Files { get; set; }  // Files that are to be added to this spaceship
        public IEnumerable<FileToApiDto> FileToApiDtos { get; set; } = new List<FileToApiDto>(); //file viewmodels

        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>(); //Images themselves that are added


        //database only properties
        public DateTime CreatedAt { get; set; } //when entry was added to the database
        public DateTime ModifiedAt { get; set; } //when wwas entry modified in the database

    }
}
