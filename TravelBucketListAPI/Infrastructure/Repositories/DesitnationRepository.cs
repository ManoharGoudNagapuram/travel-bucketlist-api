using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class DesitnationRepository : Repository<Destination>, IDesitnationRepository
    {
        public DesitnationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
