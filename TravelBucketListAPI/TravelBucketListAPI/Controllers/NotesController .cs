using System;
using Asp.Versioning;
using BusinessService.Exceptions;
using BusinessService.Interfaces;
using BusinessService.Services;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace TravelBucketListAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/destinations/{destinationId}/notes")]
    [ApiVersion("1.0")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(int destinationId, string note)
        {
           // Add Notes
           //Add validations
            try
            {
                await _notesService.AddNote(destinationId, note);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotesResponseDto>>> GetNotes(int destinationId)
        {

            var result= await _notesService.GetNotes(destinationId);
            return Ok(result);

        }
       
    }

}
