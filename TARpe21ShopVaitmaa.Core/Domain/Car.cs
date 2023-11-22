using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopVaitmaa.Core.Dto;

namespace TARpe21ShopVaitmaa.Core.Domain
{
    public class Car
    {

        public Guid Id { get; set; } // unique id
        public string CarBrand { get; set; }
        public string Description { get; set; }
        public DateTime YearMade { get; set; } //city where realestate is, city is optional incase the 
        public int HorsePower { get; set; } //postal code for the address
        public int CarPrice { get; set; } //phonenumber to call about the property
        public int CarWeight { get; set; }

        public int TopSpeed { get; set; }
        public int CarPassengerCount { get; set; } //total room count in the estate
        public string TransmissionType { get; set; } //what type of an estate is this
        public IEnumerable<FileToApi> FilesToApi { get; set; } = new List<FileToApi>(); //file viewmodels



        public DateTime CreatedAt { get; set; } //when entry was added to the database
        public DateTime ModifiedAt { get; set; } //when wwas entry modified in the database

    }
}

