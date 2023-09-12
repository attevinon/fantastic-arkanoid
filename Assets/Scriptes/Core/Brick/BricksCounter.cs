using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class BricksCounter : MonoBehaviour
    {
        private static int _bricksCount;

        private void OnEnable()
        {
            _bricksCount++;
        }

        private void OnDisable()
        {
            _bricksCount--;

            if (_bricksCount <= 0)
            {
                Debug.Log("Victory!");
            }
        }
    }
}
