using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string entityName, int id):base($"{entityName} with ID {id} not found")
        {
                
        }
    }
}
