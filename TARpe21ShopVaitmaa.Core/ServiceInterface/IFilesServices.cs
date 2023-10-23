﻿using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;

namespace TARpe21ShopVaitmaa.ApplicationServices.Services
{
    public interface IFilesServices
    {

        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
    }
}