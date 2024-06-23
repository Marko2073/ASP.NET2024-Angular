using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Searches
{
    public class LogsSearch
    {
        public string User { get; set; }
        public string UseCaseName { get; set; }
        public string Datefrom { get; set; }
        public string DateTo { get; set; }

        public int? Page { get; set; } = 1;
        public int? ItemsPerPage { get; set; } = 12;
    }
}
