using Microsoft.AspNetCore.Mvc;
using Lawnscapers.Models;
using Lawnscapers.Providers;

namespace Lawnscapers.Api.Controllers
{
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackProvider _feedbackProvider;
        public FeedbackController(IFeedbackProvider feedbackProvider)
        {
            _feedbackProvider = feedbackProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
        {
            var feedback = await _feedbackProvider.GetAllFeedbackAsync();
            return Ok(feedback);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(string id)
        {
            try
            {
                return Ok(await _feedbackProvider.GetFeedbackAsync(id));
            }
            catch (Exception)
            {
                return NotFound($"Feedback with ID {id} not found.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFeedback(Feedback feedback)
        {
            await _feedbackProvider.SubmitFeedbackAsync(feedback);
            return Ok(feedback);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(string id)
        {
            await _feedbackProvider.DeleteFeedbackAsync(id);
            return NoContent();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateFeedback(string id, Feedback updatedFeedback)
        //{
        //    try
        //    {
        //        var existingFeedback = await _feedbackProvider.GetFeedbackAsync(id);
        //    }
        //    catch(Exception)
        //    {
        //        return NotFound($"Feedback with ID {id} not found.");
        //    }

        //    return NoContent();
        //}
    }
}
