using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid.Scriptable
{
    [CreateAssetMenu(fileName = "BreakableBrickData", menuName = "ArkanoidData/BreakableBrickData")]
    public class BreakableBrickData : BrickData
    {
        public Sprite[] Sprites;
        public Color ParticlesColor;
        public int ScorePoints;
    }
}
