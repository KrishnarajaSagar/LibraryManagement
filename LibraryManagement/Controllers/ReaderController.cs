using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : Controller
    {
        private readonly IReaderRepository _readerRepository;
        public ReaderController(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reader>))]
        public IActionResult GetReaders()
        {
            var readers = _readerRepository.GetReaders();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(readers);
        }
    }
}
