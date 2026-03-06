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
    public class DestinationService : IDestinationService
    {
        private readonly IMapper _mapper;
        private readonly IDesitnationRepository _desitnationRepository;
        public DestinationService(IDesitnationRepository desitnationRepository, IMapper mapper)
        {
                _desitnationRepository = desitnationRepository;
                _mapper = mapper;
        }

        public async Task AddDestination(DestinationRequestDto requestDto )
        {
            var request = _mapper.Map<Destination>(requestDto);

            request.CreatedAt = DateTime.Now;
            await _desitnationRepository.AddAsync(request);
            await _desitnationRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<DestinationResponseDto>> GetDestinations()
        {
         
            var result= await _desitnationRepository.GetAllAsync();

            var destinationsList = _mapper.Map<List<DestinationResponseDto>>(result);

            return destinationsList;
        }

        public async Task MarkVisited(int id)
        {
            var result= await _desitnationRepository.GetByIdAsync(id);
            if(result == null)
            throw new NotFoundException("Destination", id);

            result.Visited = true;
            await _desitnationRepository.UpdateAsync(result);
            await _desitnationRepository.SaveChangesAsync();
        }
    }
}
