using FantasticArkanoid.Scriptable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    [CreateAssetMenu(fileName = "Level", menuName = "ArkanoidData/LevelData")]
    public class LevelStaticData : ScriptableObject
    {
        public List<BrickOnLevel> Bricks = new List<BrickOnLevel>();
    }

    [Serializable]
    public class BrickOnLevel
    {
        public Vector3 Position;
        public BrickData Data;
    }
}
