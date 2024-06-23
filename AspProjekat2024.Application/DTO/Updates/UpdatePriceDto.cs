﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Updates
{
    public class UpdatePriceDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

    }
}
