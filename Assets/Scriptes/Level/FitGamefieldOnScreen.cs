using UnityEngine;

namespace FantasticArkanoid.CameraOnLevel
{
    public class FitGamefieldOnScreen : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _gamefield;
        void Start()
        {
            Camera.main.orthographicSize = CalculateOrtographicSize();
        }

        private float CalculateOrtographicSize()
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = _gamefield.bounds.size.x / _gamefield.bounds.size.y;


            if (screenRatio >= targetRatio)
            {
                return _gamefield.bounds.size.y / 2;
            }
            else
            {
                float differenceInSize = targetRatio / screenRatio;
                return _gamefield.bounds.size.y / 2 * differenceInSize;
            }
        }
    }
}
