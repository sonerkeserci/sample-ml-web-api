using Microsoft.ML.Data;

namespace SampleApi.ML
{
    public class ComplaintData
    {
        [LoadColumn(0)]
        public string Text { get; set; } = string.Empty;

        [LoadColumn(1)]
        public string Category { get; set; } = string.Empty;
    }
}
