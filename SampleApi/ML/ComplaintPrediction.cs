using Microsoft.ML.Data;
namespace SampleApi.ML
{
    public class ComplaintPrediction
    {
        [ColumnName("PredictedLabel")]      // This attribute maps the "PredictedLabel" to the property. "PredictedLabel" is the default name for the predicted label in ML.NET.
        public string PredictedCategory { get; set; } = string.Empty;
        public float[] Score { get; set; } = Array.Empty<float>();
    }
}
