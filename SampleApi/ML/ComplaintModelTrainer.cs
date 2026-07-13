using Microsoft.ML;
namespace SampleApi.ML
{
    public class ComplaintModelTrainer
    {
        public static void Train()
        {
            var mlContext = new MLContext(seed: 1);// Create a new ML context for the training process, seed is set for reproducibility(rastgelelik içeren işlemlerde sonuçların daha tekrarlanabilir olması)

            //Path.Combine is used to create a path that is compatible with the operating system, so it will work on Windows, Linux, and macOS without any issues. It automatically uses the correct directory separator for the OS.

            var dataPath = Path.Combine(AppContext.BaseDirectory, "ML", "Data", "complaints.csv"); // Dataset path

            var modelFolderPath = Path.Combine(AppContext.BaseDirectory, "ML", "Models"); // Model output path

            var modelPath = Path.Combine(modelFolderPath, "complaint-model.zip"); // Model file path

            var trainingData = mlContext.Data.LoadFromTextFile<ComplaintData>(dataPath, hasHeader: true, separatorChar: ';');
            // Load the CSV data into an IDataView
            // using the ComplaintData column mapping.


            //Pipeline is a sequence of data transformations and a learning algorithm that will be applied to the training data. 
            //It defines how the data will be processed and how the model will be trained.
            var pipeline =
            mlContext.Transforms.Conversion.MapValueToKey(  // Convert the categorical labels (complaint categories) into numerical keys for the training process like "Elektrik" -> 1, "Temizlik" -> 2, etc.
                outputColumnName: "Label", // Label is the target variable (the complaint category) that we want to predict
                inputColumnName: nameof(ComplaintData.Category)) // Category = our column in .csv file. Label = ML.NET column name for the target variable

            .Append(
                mlContext.Transforms.Text.FeaturizeText( // Convert the complaint text into numerical features that can be used by the machine learning algorithm.
                    outputColumnName: "Features", // Features is a numerical vector (converted from the complaint text by FeaturizeText) that will be used to make predictions
                    inputColumnName: nameof(ComplaintData.Text)))

            // For example: Text is "Sokak lambası yanmıyor". 
            // FeaturizeText will convert the complaint text into a numerical
            // feature vector using text features such as word and character patterns.

            .Append(
                mlContext.MulticlassClassification.Trainers
                    .SdcaMaximumEntropy(  //An algorithm that is suitable for multi-class classification problems. It will learn to predict the complaint category based on the features extracted from the complaint text.
                        labelColumnName: "Label",       
                        featureColumnName: "Features")) 

            .Append(
                mlContext.Transforms.Conversion.MapKeyToValue(  // Convert the predicted numerical keys back into the original categorical labels (complaint categories) after the model has made its predictions.
                    outputColumnName: "PredictedLabel",         // PredictedLabel is the output variable (the predicted complaint category) that the model will produce after making a prediction
                    inputColumnName: "PredictedLabel"));        // The model will output a numerical key, and this step will convert it back to the original category name like "Elektrik", "Temizlik", etc.
            // Both "PredictLabel" are same thing but one is key and other is value. The first one is 2 and the second one is "Temizlik" for example.

            var model = pipeline.Fit(trainingData); // Train the model using the training data and the defined pipeline.

            Directory.CreateDirectory(modelFolderPath);

            mlContext.Model.Save(
                model,
                trainingData.Schema, // Schema is the structure(data types etc.) of the training data, which is needed to save the model correctly.
                modelPath);


        }
    }
}
