using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IEnumerable<SeriesDto> Get()
        {
            var allSeries = _seriesService.GetAll();
            return allSeries;

            //return new string[] { "value1", "value2" };
        }

        // GET api/<SeriesController>/5
        [HttpGet("{id:int}")]
        public SeriesDto Get(int id)
        {
            var series = _seriesService.GetSeries(id);
            return series;

            //return "value";
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
