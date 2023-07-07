using Microsoft.AspNetCore.Mvc;
using StateNumberManagement.Application.StateNumbers;
using StateNumberManagement.Application.StateNumbers.Request;
using StateNumberManagement.Domain;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StateNumbersController : ControllerBase
    {
        private readonly IStateNumberService _service;

        public StateNumbersController(IStateNumberService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get every item in the database based on search properties
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SearchParameters parameter, CancellationToken token)
        {
            return Ok(await _service.GetAllAsync(parameter, token));
        }

        /// <summary>
        /// Get state number with ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken token)
        {
            throw new NotImplementedException("This mothod si not implemented yer");
            var result = await _service.GetAsync(id, token);

            if(result ==  null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Add new state number
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
        /// Update existing state number with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stateNumber"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(string id, StateNumberRequestModel stateNumber, CancellationToken token)
        {
            if (await _service.GetAsync(id, token) == null)
                return BadRequest("State number not registered");

            await _service.UpdateAsync(id, stateNumber, token);

            return Ok();
        }

        /// <summary>
        /// Permenantly delete state number
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken token)
        {
            if (await _service.GetAsync(id, token) == null)
                return BadRequest("State number not registered");

            await _service.DeleteAsync(id, token);

            return Ok();
        }
    }
}
