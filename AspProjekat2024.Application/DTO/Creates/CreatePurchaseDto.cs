using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Creates
{
    public class CreatePurchaseDto
    {
        public int Quantity { get; set; }
        public int ModelVersionId { get; set; }
        public int UserId { get; set; }
    }
}
