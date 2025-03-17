using Microsoft.AspNetCore.Mvc;
using Common.DTOs.InteractionDtos;
using BusinessLogic;
using Common.ViewModels.InteractionVMs;


namespace COMP1640.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : ControllerBase
    {
        private readonly InteractionService _interactionService;

        public InteractionController(InteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        [HttpGet("get-all-interactions")]
        public async Task<IActionResult> GetAllInteractions([FromQuery] GetAllInteractionsDto dto)
        {
            IEnumerable<InteractionVM> interactions = await _interactionService.GetAllInteractions(dto);

            return Ok(interactions);
        }

        [HttpGet("get-interaction-by-id")]
        public async Task<IActionResult> GetInteractionById([FromQuery] int id)
        {
            if (id == 0)
            {
                return BadRequest("Interaction Id cannot be empty");
            }
            InteractionDetailVM user = await _interactionService.GetInteractionById(id);
            return Ok(user);
        }

    }
}
