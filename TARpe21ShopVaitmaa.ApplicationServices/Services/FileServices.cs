using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;
using TARpe21ShopVaitmaa.Data;
using TARpe21ShopVaitmaa.Data.Migrations;

namespace TARpe21ShopVaitmaa.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly TARpe21ShopVaitmaaContext _context;

        public FileServices(
            TARpe21ShopVaitmaaContext context
            )
        {
            _context = context;
        }

        public void UploadFilesToDatabase(SpaceshipDto dto, spaceship domain)
        {
            if ( dto.Files  != null && dto.Files.Count > 0) 
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            IDictionary = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            SpaceshipId = domain.Id,
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FilesToDatabase.Add(files);
                    }

                }
            
            }
        }
    }
}
