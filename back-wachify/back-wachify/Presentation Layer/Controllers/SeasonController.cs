using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Business_Logic_Layer.Interfaces;
using back_wachify.Business_Logic_Layer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_wachify.Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISaisonService _seriesService;

        public SeasonController(ISaisonService seriesService)
        {
            _seriesService = seriesService;
        }

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Season>>> GetAllSeries()
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
        public async Task<ActionResult<Season>> CreateSeries(SeasonDto series)
        {
            var createdSeries = await _seriesService.CreateSeriesAsync(series);
            return CreatedAtAction(nameof(GetSeriesById), new { id = createdSeries.SeasonID }, createdSeries);
        }

        // PUT: api/Series/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeries(int id, Season series)
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

