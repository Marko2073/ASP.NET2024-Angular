using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Gets
{
    public class OrderDto 
    {
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public IEnumerable<OrderLineDto> Products { get; set; }
    }
    public class OrderLineDto
    {

        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal Price { get; set; }
        public string Path { get; set; }
    }
}
