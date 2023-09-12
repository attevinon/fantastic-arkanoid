using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid.Scriptable
{
    [CreateAssetMenu(fileName = "BrickData", menuName = "ArkanoidData/BrickData" )]
    public class BrickData : ScriptableObject
    {
        public GameObject Prefab;
    }
}
