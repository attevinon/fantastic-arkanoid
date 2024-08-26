using UnityEngine;
using FantasticArkanoid.Level;
using FantasticArkanoid.Level.ModelAbstractions;

namespace FantasticArkanoid.UI
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
            IReadonlyLevelsProgress levelsProgresses = levelsProgressesDataAccess.GetReadonlyLevelsProgress();

            for (int i = 0; i < levelsProgresses.GetReadonlyDatas().Count; i++)
            {
                GameObject go = Instantiate(_levelButtonPrefab.gameObject, _container);

                if (go.TryGetComponent(out LevelButton button))
                {
                    button.Initialize(i + 1, levelsProgresses.GetReadonlyDatas()[i], _levelsMenu.OnLevelSelected);
                }
            }
        }
    }
}
