using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Updates
{
    public class UpdatePictureDto
    {
        public int Id { get; set; }
        public int ModelVersionId { get; set; }
        public IFormFile PicturePath { get; set; }
    }
}
