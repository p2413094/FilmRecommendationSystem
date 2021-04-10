using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace Classes
{
    public class clsMLPrediction
    {
        public clsMLPrediction()
        {
            MLContext mlContext = new MLContext();
            (IDataView trainingDataView, IDataView testDataView) = LoadData(mlContext);
            ITransformer model = BuildAndTrainModel(mlContext, trainingDataView);
            EvaluateModel(mlContext, testDataView, model);
        }
        
        public static (IDataView training, IDataView test) LoadData(MLContext mlContext)
        {            
            DatabaseLoader loader = mlContext.Data.CreateDatabaseLoader<clsFilmRating>();

            string connectionString = null;
            System.Net.WebClient client = new System.Net.WebClient();
            connectionString = client.DownloadString("http://localhost:5000/");

            string sqlCommand = "SELECT CAST(UserId as REAL) AS UserId, CAST(FilmId as REAL) AS FilmId, CAST(Rating as REAL) AS Rating FROM tblFilmRatings";

            DatabaseSource dbSource = new DatabaseSource(SqlClientFactory.Instance, connectionString, sqlCommand);

            IDataView data = loader.Load(dbSource);

            var set = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
            IDataView trainingDataView = set.TrainSet;
            IDataView testDataView = set.TestSet;

            return (trainingDataView, testDataView);
        }
        
        public static ITransformer BuildAndTrainModel(MLContext mlContext, IDataView trainingDataView)
        {
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "UserId")
            .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: "FilmId"));
        
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "movieIdEncoded",
                LabelColumnName = "Rating",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));
        
            Console.WriteLine("=============== Training the model ===============");
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            mlContext.Model.Save(model, trainingDataView.Schema, @"C:\Users\rajeshdhooper\source\repos\FilmRecommendationSystem\FilmRecommendationSystem\Model.zip");

            return model;
        }

        public static void EvaluateModel(MLContext mlContext, IDataView testDataView, ITransformer model)
        {
            Console.WriteLine("=============== Evaluating the model ===============");
            var prediction = model.Transform(testDataView);

            var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Rating", scoreColumnName: "Score");
        
            Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            Console.WriteLine("RSquared: " + metrics.RSquared.ToString());
        }

    }
}
