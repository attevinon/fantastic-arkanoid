using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FantasticArkanoid
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
                _levelsProgress.LevelsProgressDatas.Add(new LevelProgressData());
            }

            _levelsProgress.LevelsProgressDatas[0].IsOpened = true;
            SaveAllProgressData();
            Resources.UnloadUnusedAssets();
        }

        private void SaveAllProgressData()
        {
            string saveJson = JsonUtility.ToJson(_levelsProgress);
            PlayerPrefs.SetString(SAVE_KEY, saveJson);
            PlayerPrefs.Save();
        }
        public void SaveLevelProgressData(int levelIndex, LevelProgressData newProgress)
        {
            _levelsProgress = GetLevelsProgress();

            _levelsProgress.LevelsProgressDatas[levelIndex - 1] = newProgress;

            if(levelIndex - 1 != _levelsProgress.LevelsProgressDatas.Count)
            {
                _levelsProgress.LevelsProgressDatas[levelIndex].IsOpened = true;
            }

            SaveAllProgressData();
        }

        public LevelsProgress GetLevelsProgress()
        {
            if (PlayerPrefs.HasKey(SAVE_KEY))
            {
                var saveJson = PlayerPrefs.GetString(SAVE_KEY);
                _levelsProgress = JsonUtility.FromJson<LevelsProgress>(saveJson);
            }
            else
            {
                NewProgressData();
            }

            return _levelsProgress;
        }

        public void ClearData()
        {
            PlayerPrefs.DeleteKey(SAVE_KEY);
        }
    }
}
