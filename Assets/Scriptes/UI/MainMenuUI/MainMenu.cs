using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FantasticArkanoid.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private List<Button> _buttons = new List<Button>();

        public void OnPlayClicked()
        {
            EnableButtons(false);

            //loading screen

            SceneLoader.Instance.LoadScene(Scenes.LevelsMenu);
        }

        public void OnSettingsClicked()
        {
            EnableButtons(false);
            //hide pannel with buttons
            //show pannel (scrollview) with settings
        }

        public void EnableButtons(bool isEnabled)
        {
            foreach (var button in _buttons)
            {
                button.enabled = isEnabled;
            }
        }
    }
}
