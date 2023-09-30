using FantasticArkanoid.UI;
using FantasticArkanoid.Utilites;
using UnityEngine;

namespace FantasticArkanoid
{
    public class LoadingLevelState : BaseLevelState
    {
        public override void EnterState()
        {
            LoadingScreen.Instance?.Enable(true);
            Debug.Log("Enter Loading");
        }

        public override void ExitState()
        {
            LoadingScreen.Instance?.Enable(false);
            Debug.Log("Exit Loading");
        }
    }
}
