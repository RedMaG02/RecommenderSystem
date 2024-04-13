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

        public RecommenderSystem(string dataPath)
        {
            _dataPath = dataPath;
        }
        public RecommenderSystem()
        {
        }
        public void CreateItemUserMatrix()
        {
            StreamReader sr = new StreamReader(_dataPath);
            while(sr.EndOfStream) 
            {
                string line = sr.ReadLine();
                string[] stringValues = line.Split(";");
                _itemUserMatrix[(Convert.ToInt32(stringValues[0]), Convert.ToInt32(stringValues[1]))] = Convert.ToDouble(stringValues[2]);
            }
            sr.Close();
        }

        public void CreateItemTagMatrix(string itemTagPath, bool startFrom1 = false)
        {
            StreamReader sr = new StreamReader(itemTagPath);
            int corrector = startFrom1 ? 1 : 0;
            string line;
            line = sr.ReadLine();
            CultureInfo cultureInfo = new("en-US");
            while ((line = sr.ReadLine()) != null)
            {
                string[] stringValues = line.Split(",");

                int movieId = int.Parse(stringValues[0]) - corrector;
                if (movieId >= _itemTagMatrix.Count )
                {
                    int elementsToAdd = movieId - _itemTagMatrix.Count + 1;
                    for (int i = 0; i < elementsToAdd; i++)
                    {
                        _itemTagMatrix.Add(new List<float>());
                    }
                }

                int tagId = int.Parse(stringValues[1]) - corrector;
                if (tagId >= _itemTagMatrix[movieId].Count)
                {
                    for (int i = 0; i < tagId - _itemTagMatrix[movieId].Count + 1; i++)
                    {
                        _itemTagMatrix[movieId].Add(0);
                    }
                }
                _itemTagMatrix[movieId][tagId] = float.Parse(stringValues[2], NumberStyles.Currency, cultureInfo);

            }
            sr.Close();
        }

        public void CreateItemUserColumnMatrix()
        {
            StreamReader sr = new StreamReader(_dataPath);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] stringValues = line.Split(";");
                if (Convert.ToInt32(stringValues[1]) > _itemUserMatrixByColumn.Count())
                {
                    for (int i = _itemUserMatrixByColumn.Count(); i < Convert.ToInt32(stringValues[1]); i++)
                    {
                        _itemUserMatrixByColumn.Add(new List<(int, double)> ());
                    }
                }
                 
                _itemUserMatrixByColumn[Convert.ToInt32(stringValues[1])-1].Add((Convert.ToInt32(stringValues[0]) - 1, Convert.ToDouble(stringValues[2])));

                if (Convert.ToInt32(stringValues[0]) > _itemUserMatrixRowCount)
                {
                    _itemUserMatrixRowCount = Convert.ToInt32(stringValues[0]);
                }
                          
            }
            sr.Close();
        }

        public void CreateItemUserRowMatrix()
        {
            StreamReader sr = new StreamReader(_dataPath);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] stringValues = line.Split(";");
                if (Convert.ToInt32(stringValues[0]) > _itemUserMatrixByRow.Count())
                {
                    for (int i = _itemUserMatrixByRow.Count(); i < Convert.ToInt32(stringValues[0]); i++)
                    {
                        _itemUserMatrixByRow.Add(new List<(int, double)>());
                    }
                }

                _itemUserMatrixByRow[Convert.ToInt32(stringValues[0]) - 1].Add((Convert.ToInt32(stringValues[1]) - 1, Convert.ToDouble(stringValues[2])));
            }
            sr.Close();
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
            int convertedUser = user - 1;
            int convertedItem = item - 1;
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
                    return userMean + (weightsMultRatingSum / weightsAbsoluteSum);
                }
                else
                {
                    return -100;
                }
            }
            else
            {
                if (!double.IsNaN(weightsMultRatingSum / weightsAbsoluteSum))
                {
                    return weightsMultRatingSum / weightsAbsoluteSum;
                }
                else { return -100; }
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
        public double MAE(List<(int, int, double)> testValues, int k, bool useNormalization)
        {
            double sumError = 0;
            int none = 0;
            for (int i = 0; i < testValues.Count; i++)
            {
                double rating = GetPredictedRatingFromUserToItem(testValues[i].Item1, testValues[i].Item2, k, useNormalization);
                if (rating != -100)
                {
                    sumError += Math.Abs(rating - testValues[i].Item3);
                }
                else
                {
                    none++;
                }
            }
            return sumError/(testValues.Count() - none);
        }
        public double RMSE(List<(int, int, double)> testValues, int k, bool useNormalization)
        {
            double sumError = 0;
            int none = 0;
            for (int i = 0; i < testValues.Count; i++)
            {
                double rating = GetPredictedRatingFromUserToItem(testValues[i].Item1, testValues[i].Item2, k, useNormalization);
                if (rating != -100)
                {
                    sumError += Math.Pow(rating - testValues[i].Item3, 2);
                }
                else
                {
                    none++;
                }
                
            }
            return Math.Sqrt(sumError / (testValues.Count() - none));
        }
        public List<(int, int, double)> GetTestData(string filePath) 
        {
            StreamReader streamReader = new StreamReader(filePath);
            List<(int, int, double)> result = new();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] stringValues = line.Split(';');
                result.Add((Convert.ToInt32(stringValues[0]), Convert.ToInt32(stringValues[1]), Convert.ToDouble(stringValues[2])));
            }
            return result;
        }

        public void CteateItemItemSimilarityMatrixContentBased()
        {
            Random random = new Random();


            _itemItemMatrix = new();
            //for (int i = 0; i < _itemTagMatrix.Count; i++)
            //{
            //    _itemItemMatrix.Add(new List<double>());

            //    for (int j = 0; j < _itemTagMatrix.Count; j++)
                    for (int i = 0; i < 2000; i++)
            {
                _itemItemMatrix.Add(new List<double>());

                for(int j = 0; j < 2000; j++)
                {
                    _itemItemMatrix[i].Add(new double());
                    //double ijMultSum = 0;
                    //double iValuesSquareSum = 0, jValuesSquareSum = 0;

                    //for (int k = 0; k < _itemTagMatrix[0].Count; k++)
                    //{
                    //    double ikValue = _itemTagMatrix[i].Count > 0 ? _itemTagMatrix[i][k] : 0;
                    //    double jkValue = _itemTagMatrix[j].Count > 0 ? _itemTagMatrix[j][k] : 0;
                    //    ijMultSum += ikValue * jkValue;
                    //    iValuesSquareSum += Math.Pow(ikValue, 2);
                    //    jValuesSquareSum += Math.Pow(jkValue, 2);
                    //}
                    //_itemItemMatrix[i][j] = (double)(ijMultSum / (Math.Sqrt(iValuesSquareSum * jValuesSquareSum)));
                    //if (double.IsNaN(_itemItemMatrix[i][j]))
                    //{
                    //    _itemItemMatrix[i][j] = 0;
                    //}
                    _itemItemMatrix[i][j] = random.NextDouble();

                }                           
            }
        }

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
