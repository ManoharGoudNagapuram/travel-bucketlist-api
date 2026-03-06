using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace BusinessService.Interfaces
{
    public interface INotesService
    {
        Task AddNote(int destinationId, string note);
        Task<IEnumerable<NotesResponseDto>> GetNotes(int destinationId);
    }
}
