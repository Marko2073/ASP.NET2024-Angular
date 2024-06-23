using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Gets
{
    public class LogsDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public DateTime ExecutedAt { get; set; }
    }
}
