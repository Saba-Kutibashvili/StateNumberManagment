using Microsoft.AspNetCore.Mvc;
using StateNumberManagement.Application.Orders;
using StateNumberManagement.Application.StateNumbers.Request;
using StateNumberManagement.Domain;

namespace StateNumberManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StateNumberOrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public StateNumberOrdersController(IOrderService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get every order based on search properties
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SearchParameters parameter, CancellationToken token)
        {
            return Ok(await _service.GetAllAsync(parameter, token));
        }

        /// <summary>
        /// Get order with ID
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
        /// Add new order
        /// </summary>
        /// <param name="stateNumber"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(StateNumberRequestModel stateNumber, CancellationToken token)
        {
            if(await _service.NumberExistsAsync(stateNumber.Number, token))
                return BadRequest("Number already registered");

            await _service.AddAsync(stateNumber, token);

            return Ok();
        }

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(string id, CancellationToken token)
        {
            if (await _service.GetAsync(id, token) == null)
                return BadRequest("State number order doesn't exist");

            await _service.DeleteAsync(id, token);

            return Ok();
        }
    }
}
