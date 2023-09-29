using UnityEngine;

namespace FantasticArkanoid.Utilites
{
    public static class CanvasGroupExtentions
    {
        public static void EnableCanvasGroup(this CanvasGroup canvasGroup,  bool enable)
        {
            canvasGroup.alpha = enable ? 1 : 0;
            canvasGroup.interactable = enable;
        }
    }
}
