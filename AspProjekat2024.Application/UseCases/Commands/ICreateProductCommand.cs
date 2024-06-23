using AspProjekat2024.Application.DTO.Gets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.UseCases.Commands
{
    public interface ICreateProductCommand : ICommand<InsertProductDto>
    {
    }
}
