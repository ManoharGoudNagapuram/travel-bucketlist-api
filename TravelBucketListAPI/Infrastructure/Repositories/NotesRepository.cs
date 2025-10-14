using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class NotesRepository : Repository<Note>, INotesRepository
    {
        public NotesRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
