using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem
{
    public enum RecommendationTypes
    {
        CollaborativeFiltering = 0,
        ContentBasedFiltering = 1,
        MonolithHybrid = 2,
        LinearRegression = 3,
        UniformRandom = 4,
        NormalRandom = 5,
        Num = 6,
        AnsembleHybrid = 7
    }
}
