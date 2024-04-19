using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem
{
    public class RecommenderSystem
    {
        public Dictionary<ValueTuple<int, int>, double> _itemUserMatrix = new();
        public List<List<ValueTuple<int,double>>> _itemUserMatrixByColumn = new();
        public List<List<ValueTuple<int, double>>> _itemUserMatrixByRow = new();
        public int _itemUserMatrixRowCount = 0;
        public List<List<double>> _itemItemMatrix = new();
        public List<List<float>> _itemTagMatrix = new();
        public string _dataPath;
        public ValueType _valueType;
        public List<HashSet<int>> _moviesGenres;
        public Dictionary<string, int> _genres;
        public List<(int, int, double)> _testData;

        public RecommenderSystem(string dataPath)
        {
            _dataPath = dataPath;
        }
        public RecommenderSystem()
        {
        }

        public void GetGenresData(string dataPath, bool startFrom1 = true)
        {
            StreamReader sr = new StreamReader(dataPath);
            _moviesGenres = new();
            _genres = new Dictionary<string, int>();
            int corrector = startFrom1 ? 1 : 0;
            string line;
            CultureInfo cultureInfo = new("en-US");
            while ((line = sr.ReadLine()) != null)
            {
                string[] stringValues = line.Split("::");

                int movieId = int.Parse(stringValues[0]) - corrector;
                if (movieId >= _moviesGenres.Count)
                {
                    int elementsToAdd = movieId - _moviesGenres.Count + 1;
                    for (int i = 0; i < elementsToAdd; i++)
                    {
                        _moviesGenres.Add(new HashSet<int>());
                    }
                }

                string[] genres = stringValues[2].Split("|");

                foreach (string genre in genres)
                {
                    if (!_genres.ContainsKey(genre))
                    {
                        _genres[genre] = _genres.Count;
                    }
                    _moviesGenres[movieId].Add(_genres[genre]);    
                }
             }        
            sr.Close();
        }

        //public void CreateItemUserMatrix()
        //{
        //    StreamReader sr = new StreamReader(_dataPath);
        //    while(sr.EndOfStream) 
        //    {
        //        string line = sr.ReadLine();
        //        string[] stringValues = line.Split(";");
        //        _itemUserMatrix[(Convert.ToInt32(stringValues[0]), Convert.ToInt32(stringValues[1]))] = Convert.ToDouble(stringValues[2]);
        //    }
        //    sr.Close();
        //}

        //public void CreateItemTagMatrix(string itemTagPath, bool startFrom1 = false)
        //{
        //    StreamReader sr = new StreamReader(itemTagPath);
        //    int corrector = startFrom1 ? 1 : 0;
        //    string line;
        //    line = sr.ReadLine();
        //    CultureInfo cultureInfo = new("en-US");
        //    while ((line = sr.ReadLine()) != null)
        //    {
        //        string[] stringValues = line.Split(",");

        //        int movieId = int.Parse(stringValues[0]) - corrector;
        //        if (movieId >= _itemTagMatrix.Count )
        //        {
        //            int elementsToAdd = movieId - _itemTagMatrix.Count + 1;
        //            for (int i = 0; i < elementsToAdd; i++)
        //            {
        //                _itemTagMatrix.Add(new List<float>());
        //            }
        //        }

        //        int tagId = int.Parse(stringValues[1]) - corrector;
        //        if (tagId >= _itemTagMatrix[movieId].Count)
        //        {
        //            for (int i = 0; i < tagId - _itemTagMatrix[movieId].Count + 1; i++)
        //            {
        //                _itemTagMatrix[movieId].Add(0);
        //            }
        //        }
        //        _itemTagMatrix[movieId][tagId] = float.Parse(stringValues[2], NumberStyles.Currency, cultureInfo);

        //    }
        //    sr.Close();
        //}

        public void CreateItemUserColumnMatrix(string dataPath, HashSet<int> excludeItems)
        {
            StreamReader sr = new StreamReader(dataPath);
            string line;
            int count = 0;
            while ((line = sr.ReadLine()) != null && count != 100000)
            {
                string[] stringValues = line.Split("::");
                if (Convert.ToInt32(stringValues[1]) > _itemUserMatrixByColumn.Count())
                {
                    for (int i = _itemUserMatrixByColumn.Count(); i < Convert.ToInt32(stringValues[1]); i++)
                    {
                        _itemUserMatrixByColumn.Add(new List<(int, double)> ());
                    }
                }

                if (!excludeItems.Contains(count))
                {
                    _itemUserMatrixByColumn[Convert.ToInt32(stringValues[1]) - 1].Add((Convert.ToInt32(stringValues[0]) - 1, Convert.ToDouble(stringValues[2])));
                }
                count++;

                if (Convert.ToInt32(stringValues[0]) > _itemUserMatrixRowCount)
                {
                    _itemUserMatrixRowCount = Convert.ToInt32(stringValues[0]);
                }
                          
            }
            sr.Close();
        }

        private HashSet<int> GenerateRandoms(int max, int howMuch)
        {
            HashSet<int> result = new HashSet<int>();
            Random random = new Random();
            while (result.Count < howMuch) 
            {
                 result.Add(random.Next(0, max));
            }
            return result;
        }

        public void CreateItemUserRowMatrix(string dataPath, HashSet<int> excludeItems)
        {
            StreamReader sr = new StreamReader(dataPath);
            _testData = new();
            string line;
            int count = 0;
            while ((line = sr.ReadLine()) != null && count != 100000)
            {
                string[] stringValues = line.Split("::");
                if (Convert.ToInt32(stringValues[0]) > _itemUserMatrixByRow.Count())
                {
                    for (int i = _itemUserMatrixByRow.Count(); i < Convert.ToInt32(stringValues[0]); i++)
                    {
                        _itemUserMatrixByRow.Add(new List<(int, double)>());
                    }
                }
                if (!excludeItems.Contains(count))
                {
                    _itemUserMatrixByRow[Convert.ToInt32(stringValues[0]) - 1].Add((Convert.ToInt32(stringValues[1]) - 1, Convert.ToDouble(stringValues[2])));
                }
                else
                {
                    _testData.Add((int.Parse(stringValues[0]) - 1, int.Parse(stringValues[1]) - 1, Convert.ToDouble(stringValues[2])));
                }
                count++;
            }
            sr.Close();
        }

        public void CreateItemUserMatrixes(string dataPath, bool CreateTestData = true)
        {
            HashSet<int> exclude;
            if (CreateTestData)
            {
                exclude = GenerateRandoms(100000, 30000);
            }
            else
            {
                exclude = new();
            }
            CreateItemUserColumnMatrix(dataPath, exclude);
            CreateItemUserRowMatrix(dataPath, exclude);
        }

        public void PrintItemItemMatrix(string outputPath)
        {
            StreamWriter sr = new StreamWriter(outputPath);
            for (int i = 0; i< _itemItemMatrix.Count; i++) 
            {
                for (int j = 0; j< _itemItemMatrix[i].Count; j++)
                {
                    sr.Write(_itemItemMatrix[i][j] + ";");
                }
                sr.Write("\n");
            }
            sr.Close();
        }
        //max stable k = 20
        public List<(int, double, double)> GetTopKItems(int k, int user, int item)
        {
            //List<double> result = new List<double>();
            List<(int, double, double)> userItemsWithRatings = new List<(int, double, double)>();

            for (int i = 0; i < _itemUserMatrixByRow[user].Count; i++)
            {
                userItemsWithRatings.Add((_itemUserMatrixByRow[user][i].Item1, _itemItemMatrix[item][_itemUserMatrixByRow[user][i].Item1], _itemUserMatrixByRow[user][i].Item2)); 
            }
            //
            userItemsWithRatings.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            // remove self
            userItemsWithRatings.RemoveAt(0);
            return userItemsWithRatings;
           
        }

        public double GetUserMean(int user)
        {
            double sum = 0;
            for (int i= 0; i< _itemUserMatrixByRow[user].Count; i++)
            {
                sum += _itemUserMatrixByRow[user][i].Item2;
            }
            return sum / (double)_itemUserMatrixByRow[user].Count;
        }

        // max stable k = 19
        public double GetPredictedRatingFromUserToItem(int user, int item, int k, bool useNormalization) 
        {
            int convertedUser = user;
            int convertedItem = item;
            List<(int, double, double)> userItemsWithRatings = GetTopKItems(k + 1, convertedUser, convertedItem);
            double weightsMultRatingSum = 0;
            double weightsAbsoluteSum = 0;
            double userMean = GetUserMean(convertedUser);

            if (userItemsWithRatings.Count < k)
            {
                k = userItemsWithRatings.Count;
                //return -100;
            }

            for (int i = 0; i < k; i++)
            {
                if (useNormalization)
                {
                    weightsMultRatingSum += userItemsWithRatings[i].Item2 * (userItemsWithRatings[i].Item3 - userMean);
                }
                else
                {
                    weightsMultRatingSum += userItemsWithRatings[i].Item2 * userItemsWithRatings[i].Item3;
                }
                weightsAbsoluteSum += Math.Abs(userItemsWithRatings[i].Item2);
            }
            if (useNormalization)
            {
                if (!double.IsNaN(userMean + (weightsMultRatingSum / weightsAbsoluteSum)))
                {
                    return Math.Abs(userMean + (weightsMultRatingSum / weightsAbsoluteSum));
                }
                else
                {
                    return 3;
                    //return -100;
                }
            }
            else
            {
                if (!double.IsNaN(weightsMultRatingSum / weightsAbsoluteSum))
                {
                    return Math.Abs(weightsMultRatingSum / weightsAbsoluteSum);
                }
                else {
                    return 3;
                    //return -100;
                    }
            }
        }

        public void PrintUserItemMatrix(string outputFile)
        {
            StreamWriter sw = new StreamWriter(outputFile);
            for (int i = 0; i< _itemUserMatrixByColumn.Count; i++) 
            {
                List <double> vector = new List<double>();
                for (int j = 0; j< _itemUserMatrixRowCount; j++)
                {
                    vector.Add(0);
                }
                for (int j = 0; j < _itemUserMatrixByColumn[i].Count; j++)
                {
                    vector[_itemUserMatrixByColumn[i][j].Item1] = _itemUserMatrixByColumn[i][j].Item2;
                }
                for (int j = 0; j< vector.Count; j++)
                {
                    sw.Write(vector[j] + ";");
                }
                sw.Write("\n");
            }
            sw.Close();
        }

        public void PrintVector(List<double> vector, string outputFile)
        {
            StreamWriter sw = new StreamWriter(outputFile);
            for (int i =0; i< vector.Count; i++)
            {
                sw.Write(vector[i] + ";");
            }
            sw.Close ();
        }

        private List<double> GetPredictedRatings (List<(int, int)> testValues, int k, bool useNormalization)
        {
            List<double> result = new List<double>();
            foreach (var val in testValues)
            {
                result.Add(GetPredictedRatingFromUserToItem(val.Item1, val.Item2, k, useNormalization));
            }
            return result;
        }

        public (double[,], double, double, double) ProcessTest(List<(int, int, double)> testValues, int k, bool useNormalization)
        {
            List<(int, int)> userMovieList = testValues
                .Select(x => (x.Item1, x.Item2)).ToList();
            List<double> predictedRatings = GetPredictedRatings(userMovieList, k, useNormalization);
            List<(double, double)> predictedActualRatings = predictedRatings.Zip(testValues, (first, second) => (first, second.Item3)).ToList();

            double mae = MAE(predictedActualRatings);
            double rmse = RMSE(predictedActualRatings);
            double r = DeterminationKoef(predictedActualRatings);
            double[,] data = GetDataForChart(predictedActualRatings);

            return (data, mae, rmse, r);
        }

        public double[,] GetDataForChart(List<(double, double)> data)
        {
            int[,] stars = new int[5, 5];
            double actual, predicted;
            for (int i = 0; i < data.Count;  i++)
            {
                predicted = data[i].Item1 > 0.5 ? data[i].Item1 : 1;
                actual = data[i].Item2;
                stars[(int)actual - 1, (int)Math.Round(predicted) - 1]++;
            }
            double[,] result = new double[5, 5];

            for (int i = 0; i < 5; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    count += stars[i,j];
                }
                for (int j = 0;j < 5; j++)
                {
                    result[i,j] = (double)stars[i,j]/count;
                }
            }
            return result;
        }

        public double MAE(List<(double, double)> testValues)
        {
            double sumError = 0;
            int none = 0;
            for (int i = 0; i < testValues.Count; i++)
            {
                double predRating = testValues[i].Item1;
                double actualRating = testValues[i].Item2;
                if (predRating != -100)
                {
                    sumError += Math.Abs(predRating - actualRating);
                }
                else
                {
                    none++;
                }
            }
            return sumError/(testValues.Count() - none);
        }

        public double RMSE(List<(double, double)> testValues)
        {
            double sumError = 0;
            int none = 0;
            for (int i = 0; i < testValues.Count; i++)
            {
                double predRating = testValues[i].Item1;
                double actualRating = testValues[i].Item2;
                if (predRating != -100)
                {
                    sumError += Math.Pow(predRating - actualRating, 2);
                }
                else
                {
                    none++;
                }
                
            }
            return Math.Sqrt(sumError / (testValues.Count() - none));
        }


        public double DeterminationKoef(List<(double, double)> testValues)
        {
            double rmse = RMSE(testValues);

            double average = testValues.Average(x => x.Item2);
            List<(double, double)> averageActual = testValues.Select(x => (average, x.Item2)).ToList();
            double averageRMSE = RMSE(averageActual);

            return 1 - (rmse / averageRMSE);
        }


        public void GetTestData(string filePath) 
        {
            StreamReader streamReader = new StreamReader(filePath);
            List<(int, int, double)> result = new();
            string line;
            int count = 0;
            while ((line = streamReader.ReadLine()) != null && count != 100000)
            {
                string[] stringValues = line.Split("::");
                result.Add((Convert.ToInt32(stringValues[0]) - 1, Convert.ToInt32(stringValues[1]) -1, Convert.ToDouble(stringValues[2])));
                count++;
            }
            _testData = result;
        }

        //public void CteateItemItemSimilarityMatrixContentBased()
        //{
        //    Random random = new Random();


        //    _itemItemMatrix = new();
        //    //for (int i = 0; i < _itemTagMatrix.Count; i++)
        //    //{
        //    //    _itemItemMatrix.Add(new List<double>());

        //    //    for (int j = 0; j < _itemTagMatrix.Count; j++)
        //            for (int i = 0; i < 2000; i++)
        //    {
        //        _itemItemMatrix.Add(new List<double>());

        //        for(int j = 0; j < 2000; j++)
        //        {
        //            _itemItemMatrix[i].Add(new double());
        //            //double ijMultSum = 0;
        //            //double iValuesSquareSum = 0, jValuesSquareSum = 0;

        //            //for (int k = 0; k < _itemTagMatrix[0].Count; k++)
        //            //{
        //            //    double ikValue = _itemTagMatrix[i].Count > 0 ? _itemTagMatrix[i][k] : 0;
        //            //    double jkValue = _itemTagMatrix[j].Count > 0 ? _itemTagMatrix[j][k] : 0;
        //            //    ijMultSum += ikValue * jkValue;
        //            //    iValuesSquareSum += Math.Pow(ikValue, 2);
        //            //    jValuesSquareSum += Math.Pow(jkValue, 2);
        //            //}
        //            //_itemItemMatrix[i][j] = (double)(ijMultSum / (Math.Sqrt(iValuesSquareSum * jValuesSquareSum)));
        //            //if (double.IsNaN(_itemItemMatrix[i][j]))
        //            //{
        //            //    _itemItemMatrix[i][j] = 0;
        //            //}
        //            _itemItemMatrix[i][j] = random.NextDouble();

        //        }                           
        //    }
        //}

        public void CteateItemItemSimilarityMatrix()
        {
            List<double> columnMeans = new List<double>();
            
            for(int i = 0; i<  _itemUserMatrixByColumn.Count; i++)
            {
                double sum = 0;
                if (_itemUserMatrixByColumn[i].Count() == 0)
                {
                    columnMeans.Add(sum);
                }
                else
                {
                    for (int j = 0; j < _itemUserMatrixByColumn[i].Count(); j++)
                    {
                        sum += _itemUserMatrixByColumn[i][j].Item2;
                        //sum += _itemUserMatrixByColumn[j][i].Item2;
                    }
                    columnMeans.Add((double)(sum / _itemUserMatrixByColumn[i].Count()));
                }
            }

            //PrintVector(columnMeans, @"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\MeanVector.csv");

            for (int i = 0; i< _itemUserMatrixByColumn.Count(); i++)
            {
                _itemItemMatrix.Add(new List<double>());
                for (int j = 0; j< _itemUserMatrixByColumn.Count(); j++)
                {
                    _itemItemMatrix[i].Add(new double());
                    double ijMultSum = 0;
                    double iValuesSquareSum = 0, jValuesSquareSum = 0;

                    for (int k = 0; k < _itemUserMatrixByColumn[i].Count; k++)
                    {
                        for (int c = 0; c < _itemUserMatrixByColumn[j].Count; c++)
                        {
                            if (_itemUserMatrixByColumn[i][k].Item1 == _itemUserMatrixByColumn[j][c].Item1)
                            {
                                ijMultSum += ((_itemUserMatrixByColumn[i][k].Item2 - columnMeans[i]) * (_itemUserMatrixByColumn[j][c].Item2 - columnMeans[j]));
                                iValuesSquareSum += Math.Pow(_itemUserMatrixByColumn[i][k].Item2 - columnMeans[i], 2);
                                jValuesSquareSum += Math.Pow(_itemUserMatrixByColumn[j][c].Item2 - columnMeans[j], 2);
                            }

                        }
                    }
                    _itemItemMatrix[i][j] = (double)(ijMultSum / (Math.Sqrt(iValuesSquareSum * jValuesSquareSum)));
                    if (double.IsNaN(_itemItemMatrix[i][j]))
                    {
                        _itemItemMatrix[i][j] = 0;
                    }
                }
            }
        }

        public void CteateItemItemSimilarityMatrixGenresBasedV1()
        {
            _itemItemMatrix = new();
            for (int i = 0; i < _itemUserMatrixByColumn.Count; i++)
            {
                _itemItemMatrix.Add(new List<double>());

                for (int j = 0; j < _itemUserMatrixByColumn.Count; j++)
                {
                    _itemItemMatrix[i].Add(new double());
                    double ijMultSum = 0;
                    double iValuesSquareSum = 0, jValuesSquareSum = 0;

                    for (int k = 0; k < _genres.Count; k++)
                    {
                        double ikValue = _moviesGenres[i].Contains(k) ? 1 : 0;
                        double jkValue = _moviesGenres[j].Contains(k) ? 1 : 0;
                        ijMultSum += ikValue * jkValue;
                        iValuesSquareSum += Math.Pow(ikValue, 2);
                        jValuesSquareSum += Math.Pow(jkValue, 2);
                    }
                    _itemItemMatrix[i][j] = (double)(ijMultSum / (Math.Sqrt(iValuesSquareSum * jValuesSquareSum)));
                    if (double.IsNaN(_itemItemMatrix[i][j]))
                    {
                        _itemItemMatrix[i][j] = 0;
                    }

                }
            }
        }


        public void CteateItemItemSimilarityMatrixGenresBasedV2()
        {
            _itemItemMatrix = new();
            for (int i = 0; i < _itemUserMatrixByColumn.Count; i++)
            {
                _itemItemMatrix.Add(new List<double>());

                for (int j = 0; j < _itemUserMatrixByColumn.Count; j++)
                {
                    _itemItemMatrix[i].Add(new double());
                    double ijMultSum = 0;
                    double iValuesSquareSum = 0, jValuesSquareSum = 0;

                    for (int k = 0; k < _genres.Count; k++)
                    {
                        if (_moviesGenres[i].Contains(k) || _moviesGenres[j].Contains(k))
                        {
                            double ikValue = _moviesGenres[i].Contains(k) ? 1 : 0;
                            double jkValue = _moviesGenres[j].Contains(k) ? 1 : 0;
                            ijMultSum += ikValue * jkValue;
                            iValuesSquareSum += Math.Pow(ikValue, 2);
                            jValuesSquareSum += Math.Pow(jkValue, 2);
                        }
                    }
                    _itemItemMatrix[i][j] = (double)(ijMultSum / (Math.Sqrt(iValuesSquareSum * jValuesSquareSum)));
                    if (double.IsNaN(_itemItemMatrix[i][j]))
                    {
                        _itemItemMatrix[i][j] = 0;
                    }

                }
            }
        }



        public void CteateItemItemSimilarityMatrixAC()
        {
            List<double> rowMeans = new List<double>();

            for (int i = 0; i < _itemUserMatrixByRow.Count; i++)
            {
                double sum = 0;
                if (_itemUserMatrixByRow[i].Count() == 0)
                {
                    rowMeans.Add(sum);
                }
                else
                {
                    for (int j = 0; j < _itemUserMatrixByRow[i].Count(); j++)
                    {
                        sum += _itemUserMatrixByRow[i][j].Item2;
                        //sum += _itemUserMatrixByRow[j][i].Item2;
                    }
                    rowMeans.Add((double)(sum / _itemUserMatrixByRow[i].Count()));
                }
            }


            //PrintVector(rowMeans, @"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\MeanVector.csv");



            for (int i = 0; i < _itemUserMatrixByColumn.Count(); i++)
            {
                _itemItemMatrix.Add(new List<double>());
                for (int j = 0; j < _itemUserMatrixByColumn.Count(); j++)
                {
                    _itemItemMatrix[i].Add(new double());
                    double ijMultSum = 0;
                    double iValuesSquareSum = 0, jValuesSquareSum = 0;

                    for (int k = 0; k < _itemUserMatrixByColumn[i].Count; k++)
                    {
                        for (int c = 0; c < _itemUserMatrixByColumn[j].Count; c++)
                        {
                            if (_itemUserMatrixByColumn[i][k].Item1 == _itemUserMatrixByColumn[j][c].Item1)
                            {
                                ijMultSum += ((_itemUserMatrixByColumn[i][k].Item2 - rowMeans[_itemUserMatrixByColumn[i][k].Item1]) * (_itemUserMatrixByColumn[j][c].Item2 - rowMeans[_itemUserMatrixByColumn[j][c].Item1]));
                                iValuesSquareSum += Math.Pow(_itemUserMatrixByColumn[i][k].Item2 - rowMeans[_itemUserMatrixByColumn[i][k].Item1], 2);
                                jValuesSquareSum += Math.Pow(_itemUserMatrixByColumn[j][c].Item2 - rowMeans[_itemUserMatrixByColumn[i][k].Item1], 2);
                            }

                        }
                    }
                    _itemItemMatrix[i][j] = (double)(ijMultSum / (Math.Sqrt(iValuesSquareSum * jValuesSquareSum)));
                    if (double.IsNaN(_itemItemMatrix[i][j]))
                    {
                        _itemItemMatrix[i][j] = 0;
                    }
                }
            }
        }
    }
}
