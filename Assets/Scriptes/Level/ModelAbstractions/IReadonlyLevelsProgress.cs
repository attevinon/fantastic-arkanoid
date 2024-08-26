using System;
using System.Collections.Generic;
using System.Linq;

namespace FantasticArkanoid.Level.ModelAbstractions
{
    public interface IReadonlyLevelsProgress
    {
        public IReadOnlyList<IReadonlyLevelProgress> GetReadonlyDatas();
    }
}
