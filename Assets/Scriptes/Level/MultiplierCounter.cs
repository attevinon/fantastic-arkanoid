using System;
using UnityEngine;

namespace FantasticArkanoid
{
    public class MultiplierCounter : MonoBehaviour
    {
        private int _multiplier;
        public static int BestResult { get; private set; }
        public static int SummaryMultiplier { get; private set; }
        public static event Action<int> MultiplierUpdated;

        private void OnDisable()
        {
            ResetMultiplier();
        }
        public void InscreaceMultiplier()
        {
            _multiplier++;
            SummaryMultiplier++;

            if (SummaryMultiplier > BestResult)
            {
                BestResult = SummaryMultiplier;
            }

            MultiplierUpdated?.Invoke(SummaryMultiplier);
        }
        public void ResetMultiplier()
        {
            SummaryMultiplier -= _multiplier;
            if(SummaryMultiplier < 0)
            {
                Debug.LogError("Summary Multiplier is less than 0!");
            }
            _multiplier = 0;

            MultiplierUpdated?.Invoke(SummaryMultiplier);
        }
    }
}
