using AutoMapper;
using LibraryManagement.Dto;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : Controller
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IMapper _mapper;

        public ReaderController(IReaderRepository readerRepository, IMapper mapper)
        {
            _readerRepository = readerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reader>))]
        public IActionResult GetReaders()
        {
            var readers = _mapper.Map<List<ReaderDto>>(_readerRepository.GetReaders());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(readers);
        }

        [HttpGet("{readerId}")]
        [ProducesResponseType(200, Type = typeof(Reader))]
        [ProducesResponseType(400)]
        public IActionResult GetReader(int readerId)
        {
            if (!_readerRepository.ReaderExists(readerId))
                return NotFound();

            var reader = _mapper.Map<ReaderDto>(_readerRepository.GetReader(readerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reader);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReader([FromBody] ReaderDto readerCreate)
        {
            if (readerCreate == null)
                return BadRequest(ModelState);

            var reader = _readerRepository.GetReaders()
                .Where(r => r.Name.Trim().ToUpper() == readerCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(reader != null)
            {
                ModelState.AddModelError("", "Reader already exists");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var readerMap = _mapper.Map<Reader>(readerCreate);

            if(!_readerRepository.CreateReader(readerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
