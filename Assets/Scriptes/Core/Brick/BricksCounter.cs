using System;
using UnityEngine;

namespace FantasticArkanoid
{
    public class BricksCounter : MonoBehaviour
    {
        private static int _bricksCount;
        public static event Action OnBricksDisabled;

        private void OnEnable()
        {
            _bricksCount++;
        }

        private void OnDisable()
        {
            _bricksCount--;

            if (_bricksCount <= 0)
            {
                OnBricksDisabled?.Invoke();
            }
        }
    }
}
