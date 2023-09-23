using FantasticArkanoid.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class LevelButtonsInitializer : MonoBehaviour
    {
        [SerializeField] private LevelButton _levelButtonPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private LevelsMenu _levelsMenu;

        private int numOfLevels = 10; //will be replaced with LevelProgress

        private void Start()
        {
            InitializeButtons();
        }

        public void InitializeButtons()
        {
            for (int i = 0; i < numOfLevels; i++)
            {
                GameObject go = Instantiate(_levelButtonPrefab.gameObject, _container);

                if (go.TryGetComponent(out LevelButton button))
                {
                    button.Initialize(i + 1, _levelsMenu);
                }
            }
        }
    }
}
