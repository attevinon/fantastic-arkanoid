using UnityEngine;

namespace FantasticArkanoid
{
    public class LevelCleaner : MonoBehaviour
    {
        public void CleanLevel()
        {
            BaseBrick[] allBricks = FindObjectsOfType<BaseBrick>();

            if (allBricks.Length <= 0)
                return;

            foreach (var brick in allBricks)
            {
#if UNITY_EDITOR
                DestroyImmediate(brick.gameObject);
#else
                Destroy(brick.gameObject);
#endif
            }
        }
    }
}
