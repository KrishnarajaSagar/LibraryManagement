using AutoMapper;
using LibraryManagement.Dto;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
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

        [HttpPut("{readerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult UpdateReader(int readerId, [FromBody] ReaderDto updatedReader)
        {
            if (updatedReader == null)
                return BadRequest(ModelState);

            if (readerId != updatedReader.Id)
                return BadRequest(ModelState);

            if (!_readerRepository.ReaderExists(readerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var readerMap = _mapper.Map<Reader>(updatedReader);

            if (!_readerRepository.UpdateReader(readerMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{readerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReader(int readerId)
        {
            if (!_readerRepository.ReaderExists(readerId))
                return NotFound();

            var readerToDelete = _readerRepository.GetReader(readerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_readerRepository.DeleteReader(readerToDelete))
                ModelState.AddModelError("", "Something went wrong while deleting");

            return Ok("Successfully deleted");
        }
    }
}
