using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timeline.Service;

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
        public async Task<ActionResult> Get()
        {
            var allSeries = await _seriesService.GetAllAsync();
            return Ok(allSeries);
        }

        // GET api/<SeriesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var series = await _seriesService.GetSeriesAsync(id);
            return Ok(series);
        }

        // POST api/<SeriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
