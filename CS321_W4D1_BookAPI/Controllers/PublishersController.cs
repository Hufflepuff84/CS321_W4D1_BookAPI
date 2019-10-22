using CS321_W4D1_BookAPI.ApiModels;
using CS321_W4D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W4D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        // Constructor
        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET api/publisher
        [HttpGet]
        public IActionResult Get()
        {
            // TODO: convert domain models to apimodels
            var publisherModels = _publisherService
                .GetAll()
                .ToApiModels(); // convert Books to BookModels

            return Ok(publisherModels);
        }

        // get specific book by id
        // GET api/books/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // TODO: convert domain model to apimodel
            var publisher = _publisherService.Get(id).ToApiModel();
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // create a new publisher
        // POST api/publishers
        [HttpPost]
        public IActionResult Post([FromBody] PublisherModel newPublisher)
        {
            try
            {
                // Done: convert apimodel to domain model
                // add the new book
                _publisherService.Add(newPublisher.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddPublisher", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        // Done: update an existing publisher
        // PUT api/publisher/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PublisherModel updatedPublisher)
        {
            var publisher = _publisherService.Update(updatedPublisher.ToDomainModel());
            if (publisher == null) return NotFound();
            return Ok(publisher.ToApiModel());
        }

        // Done: delete an existing author
        // DELETE api/publisher/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            _publisherService.Remove(publisher);
            return NoContent();
        }
    }
}