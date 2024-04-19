using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem
{
    public static class DataAnalysis
    {

        public static List<(int, int, double)> GetRatingData(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            List<(int, int, double)> result = new();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] stringValues = line.Split("::");
                result.Add((Convert.ToInt32(stringValues[0]) - 1, Convert.ToInt32(stringValues[1]) - 1, Convert.ToDouble(stringValues[2])));
            }
            return result;
        }

        public static (float, float, float, float, float) GetUserData(List<(int, int, double)> data)
        {
            List<float> values = data
                .GroupBy(x => x.Item1)
                .Select(group => Convert.ToSingle(group.Count()))
                .ToList();

            return GetStatistics(values);
        }

        public static (float, float, float, float, float) GetMoviesData(List<(int, int, double)> data)
        {
            List<float> values = data
                .GroupBy(x => x.Item2)
                .Select(group => Convert.ToSingle(group.Count()))
                .ToList();

            return GetStatistics(values);
        }

        public static (float, float, float, float, float) GetStatistics(List<float> values)
        {
            float min = values.Min();
            float max = values.Max();
            float average = values.Average();
            float mode = values
                .GroupBy(x => x)
                .OrderByDescending(c => c.Count())
                .First()
                .Key;
            List<float> sorted = values.OrderByDescending(x => x).ToList();
            float median = sorted[sorted.Count / 2];
            return (min, max, average, mode, median);
        }

        public static SortedDictionary<T, int> GetDistribution<T>(List<T> values)
        {
            SortedDictionary<T, int> result = new SortedDictionary<T, int>();
            var groups = values.GroupBy(x => x);
            foreach ( var group in groups)
            {
                result[group.Key] = group.Count();
            }
            return result;
        }

    }
}
