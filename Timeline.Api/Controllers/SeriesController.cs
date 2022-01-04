using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timeline.Service;
using TimeLine.Common.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Timeline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        // GET: api/<SeriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeriesDto>>> Get()
        {
            var allSeries = await _seriesService.RetrieveAllAsync();
            return Ok(allSeries);
        }

        // GET api/<SeriesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SeriesDto>> Get(int id)
        {
            var series = await _seriesService.RetrieveSeriesAsync(id);
            return Ok(series);
        }

        // POST api/<SeriesController>
        [HttpPost]
        public async Task<ActionResult<SeriesDto>> Post([FromBody] SeriesDto seriesDto)
        {
            if (seriesDto == null) 
                return BadRequest();

            var savedSeries = await _seriesService.CreateAsync(seriesDto);

            return Ok(savedSeries);
        }

        // PUT api/<SeriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SeriesDto>> Put(int id, [FromBody] SeriesDto seriesDto)
        {
            if (seriesDto == null || seriesDto.Id != id)
                return BadRequest();

            var updatedSeries = await _seriesService.UpdateAsync(id, seriesDto);
            if (updatedSeries == null)
            {
                return NotFound();
            }

            return Ok(updatedSeries);
        }

        // DELETE api/<SeriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
