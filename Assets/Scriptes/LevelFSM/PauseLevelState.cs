using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class PauseLevelState : BaseLevelState
    {
        public PauseLevelState() 
        {
        }
        public override void EnterState()
        {
            Time.timeScale = 0f;
        }

        public override void ExitState()
        {
            Time.timeScale = 1f;
        }

    }
}
