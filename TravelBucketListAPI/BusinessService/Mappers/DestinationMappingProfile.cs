using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Models;
using Shared.DTOs;

namespace BusinessService.Mappers
{
    public class DestinationMappingProfile:Profile
    {
        public DestinationMappingProfile()
        {
            CreateMap<Destination,DestinationResponseDto>();
            CreateMap<DestinationRequestDto, Destination>();
            CreateMap<Note, NotesResponseDto>();
        }
    }
}
