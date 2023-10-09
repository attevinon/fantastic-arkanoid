using UnityEngine;
using FantasticArkanoid.UI;

namespace FantasticArkanoid
{
    public class LevelButtonsInitializer : MonoBehaviour
    {
        [SerializeField] private LevelButton _levelButtonPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private LevelsMenu _levelsMenu;

        private void Start()
        {
            InitializeButtons();
        }

        public void InitializeButtons()
        {
            LevelsProgressDataAccess levelsProgressesDataAccess = new LevelsProgressDataAccess();
            LevelsProgress levelsProgresses = levelsProgressesDataAccess.GetLevelsProgress();

            for (int i = 0; i < levelsProgresses.LevelsProgressDatas.Count; i++)
            {
                GameObject go = Instantiate(_levelButtonPrefab.gameObject, _container);

                if (go.TryGetComponent(out LevelButton button))
                {
                    button.Initialize(i + 1, levelsProgresses.LevelsProgressDatas[i], _levelsMenu.OnLevelSelected);
                }
            }
        }
    }
}
