using Asp.Versioning;
using BusinessService.Exceptions;
using BusinessService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace TravelBucketListAPI.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<DestinationResponseDto>>> GetDestinations()
        {
            var result = await _destinationService.GetDestinations();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddDestination(DestinationRequestDto requestDto)
        {
            await _destinationService.AddDestination(requestDto);

            return Ok();
        }

        [HttpPatch("{id}/visit")]
        public async Task<IActionResult> MarkVisited(int id)
        {

            await _destinationService.MarkVisited(id);

            return Ok();

        }
    }
}
