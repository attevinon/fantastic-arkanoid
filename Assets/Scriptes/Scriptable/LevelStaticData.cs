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
        public List<BrickObject> Bricks = new List<BrickObject>();
    }

    [Serializable]
    public class BrickObject
    {
        public Vector3 Position;
        public BrickData Data;
    }
}
