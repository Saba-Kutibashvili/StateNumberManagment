using Microsoft.AspNetCore.Mvc;
using StateNumberManagement.Application.StateNumberReservations;
using StateNumberManagement.Application.StateNumberReservations.Request;
using StateNumberManagement.Domain;

namespace StateNumberManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StateNumberReservationsController : ControllerBase
    {
        private readonly IReservationService _service;

        public StateNumberReservationsController(IReservationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get every reservation based on search properties
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SearchParameters parameter, CancellationToken token)
        {
            return Ok(await _service.GetAllAsync(token));
        }

        /// <summary>
        /// Get reservation with ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken token)
        {
            var result = await _service.GetAsync(id, token);

            if(result ==  null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Add new reservation
        /// </summary>
        /// <param name="stateNumber"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(StateNumberReservationRequestModel stateNumber, CancellationToken token)
        {
            if(await _service.NumberExistsAsync(stateNumber.Number, token))
                return BadRequest("Number already registered");

            await _service.AddAsync(stateNumber, token);

            return Ok();
        }

        /// <summary>
        /// Cancel reservation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(string id, CancellationToken token)
        {
            if (await _service.GetAsync(id, token) == null)
                return BadRequest("State number reservation not registered");

            await _service.DeleteAsync(id, token);

            return Ok();
        }
    }
}
