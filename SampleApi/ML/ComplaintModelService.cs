using Microsoft.ML;
namespace SampleApi.ML
{
    public class ComplaintModelService
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;

        public ComplaintModelService()
        {
            _mlContext = new MLContext();
            
        }
    }
}
