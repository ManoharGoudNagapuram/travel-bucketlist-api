using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Shared.DTOs;

namespace BusinessService.Interfaces
{
    public interface IDestinationService
    {
        Task<IEnumerable<DestinationResponseDto>> GetDestinations();
        Task AddDestination(DestinationRequestDto requestDto);
        Task MarkVisited(int id);
       
    }
}
