using FantasticArkanoid.UI;
using FantasticArkanoid.Utilites;
using System;
using UnityEngine;

namespace FantasticArkanoid
{
    public class LoadingLevelState : BaseLevelState
    {
        public override void EnterState()
        {
            Debug.Log("Enter Loading");
        }

        public override void ExitState()
        {
            Debug.Log("Exit Loading");
        }
    }
}
