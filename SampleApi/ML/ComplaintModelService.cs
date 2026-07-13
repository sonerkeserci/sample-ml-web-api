using Microsoft.Extensions.ML;
namespace SampleApi.ML
{
    public class ComplaintModelService
    {
        private const string ModelName = "ComplaintModel";

        private readonly PredictionEnginePool<ComplaintData, ComplaintPrediction> _predictionPool;

        public ComplaintModelService (PredictionEnginePool<ComplaintData, ComplaintPrediction> predictionPool)
        {
            _predictionPool = predictionPool;
        }

        public ComplaintPrediction Predict (string text)
        {
            var input = new ComplaintData { Text = text };

            return _predictionPool.Predict (ModelName,input);
        }
    }
}
