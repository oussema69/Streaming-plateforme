using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Business_Logic_Layer.Model;
using back_wachify.Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_wachify.Presentation_Layer.Controllers
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

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Series>>> GetAllSeries()
        {
            var series = await _seriesService.GetAllSeriesAsync();
            return Ok(series);
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Series>> GetSeriesById(int id)
        {
            var series = await _seriesService.GetSeriesByIdAsync(id);
            if (series == null)
            {
                return NotFound();
            }

            return Ok(series);
        }

        // POST: api/Series
        [HttpPost]
        public async Task<ActionResult<Series>> CreateSeries(SeriesDto series)
        {
            var createdSeries = await _seriesService.CreateSeriesAsync(series);
            return CreatedAtAction(nameof(GetSeriesById), new { id = createdSeries.SeriesID }, createdSeries);
        }

        // PUT: api/Series/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSeries(int id, Series series)
        {
            if (id != series.SeriesID)
            {
                return BadRequest();
            }

            var updatedSeries = await _seriesService.UpdateSeriesAsync(id, series);
            if (updatedSeries == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            var result = await _seriesService.DeleteSeriesAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
