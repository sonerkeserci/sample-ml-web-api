using Microsoft.AspNetCore.Mvc;
using SampleApi.ML;
using SampleApi.Requests;

namespace SampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintController : ControllerBase
    {
        private readonly ComplaintModelService _modelService;

        public ComplaintController(ComplaintModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost("predict")]
        public ActionResult<ComplaintPrediction> Predict(PredictComplaintRequest request)
        {
            var prediction = _modelService.Predict(request.ComplaintText);

            return Ok(prediction);
        }
    }
}
