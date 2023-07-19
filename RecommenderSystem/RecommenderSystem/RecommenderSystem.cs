using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public string _dataPath;

        public RecommenderSystem(string dataPath)
        {
            _dataPath = dataPath;
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
                return userMean * (weightsMultRatingSum / weightsAbsoluteSum);
            }
            else
            {
                return weightsMultRatingSum / weightsAbsoluteSum;
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


            PrintVector(columnMeans, @"J:\RecommenderSystem\RecommenderSystem\RecommenderSystem\MeanVector.csv");



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
    }
}
