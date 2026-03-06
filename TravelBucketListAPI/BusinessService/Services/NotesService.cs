using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessService.Exceptions;
using BusinessService.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Shared.DTOs;

namespace BusinessService.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;
        private readonly IDesitnationRepository _desitnationRepository;
        private IMapper _mapper;
        public NotesService(INotesRepository notesRepository,
            IDesitnationRepository desitnationRepository, IMapper mapper)
        {
            _notesRepository = notesRepository;
            _desitnationRepository = desitnationRepository;
            _mapper = mapper;
        }
        public async Task AddNote(int destinationId, string note)
        {
            var result = await _desitnationRepository.GetByIdAsync(destinationId);
            if (result == null)
                throw new NotFoundException(nameof(Destination), destinationId);

            await _notesRepository.AddAsync(new Note { Content = note, DestinationId = destinationId, CreatedAt=DateTime.Now });
        }

        public async Task<IEnumerable<NotesResponseDto>> GetNotes(int destinationId)
        {
            var result = await _notesRepository.GetAllAsync();
            if (result == null)
                return Enumerable.Empty<NotesResponseDto>();

            var notes = _mapper.Map<List<NotesResponseDto>>(result);
            return notes;
        }
    }
}
