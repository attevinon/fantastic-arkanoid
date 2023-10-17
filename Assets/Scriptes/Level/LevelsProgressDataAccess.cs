using UnityEngine;
using Newtonsoft.Json;
using FantasticArkanoid.Level.ModelAbstractions;
using FantasticArkanoid.Level.Model;

namespace FantasticArkanoid.Level
{
    public class LevelsProgressDataAccess
    {
        private const string SAVE_KEY = "progresses";
        private LevelsProgress _levelsProgress;

        public LevelsProgressDataAccess()
        {
            _levelsProgress = new LevelsProgress();
        }
        private void NewProgressData()
        {
            int levelsCount = Resources.LoadAll<LevelStaticData>("Levels").Length;

            for (int i = 0; i < levelsCount; i++)
            {
                _levelsProgress.DatasList.Add(new LevelProgressData());
            }

            _levelsProgress.DatasList[0].IsOpened = true;
            SaveAllProgressData();
            Resources.UnloadUnusedAssets();
        }

        private void SaveAllProgressData()
        {
            string saveJson = JsonConvert.SerializeObject(_levelsProgress);
            PlayerPrefs.SetString(SAVE_KEY, saveJson);
            PlayerPrefs.Save();
        }

        private LevelsProgress GetLevelsProgress()
        {
            if (PlayerPrefs.HasKey(SAVE_KEY))
            {
                var saveJson = PlayerPrefs.GetString(SAVE_KEY);
                _levelsProgress = JsonConvert.DeserializeObject<LevelsProgress>(saveJson);
            }
            else
            {
                NewProgressData();
            }

            return _levelsProgress;
        }

        public void SaveLevelProgressData(int levelIndex, LevelProgressData newProgress)
        {
            _levelsProgress = GetLevelsProgress();

            _levelsProgress.DatasList[levelIndex - 1] = newProgress;

            if(levelIndex - 1 < _levelsProgress.DatasList.Count)
            {
                _levelsProgress.DatasList[levelIndex].IsOpened = true;
            }

            SaveAllProgressData();
        }

        public IReadonlyLevelsProgress GetReadonlyLevelsProgress()
        {
            return  GetLevelsProgress();
        }

        public IReadonlyLevelProgress GetLevelProgressData(int index)
        {
            _levelsProgress = GetLevelsProgress();

            if(index - 1 >= 0 && index - 1 < _levelsProgress.DatasList.Count)
            {
                LevelProgressData levelProgressData = _levelsProgress.DatasList[index - 1];
                return levelProgressData;
            }

            return null;
        }

        public void ClearData()
        {
            PlayerPrefs.DeleteKey(SAVE_KEY);
        }
    }
}
