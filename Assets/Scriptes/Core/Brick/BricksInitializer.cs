using UnityEngine;
using FantasticArkanoid.Scriptable;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FantasticArkanoid
{
    public class BricksInitializer : MonoBehaviour
    {
        public void InitializeBricks(LevelStaticData levelData, Transform parent, Action<int> onScorePointsKnockedOut)
        {
            for (int i = 0; i < levelData.Bricks.Count; i++)
            {
                GameObject go;

#if UNITY_EDITOR
                go = PrefabUtility.InstantiatePrefab(levelData.Bricks[i].Data.Prefab, parent) as GameObject;

                if(go.TryGetComponent(out BaseBrick baseBrick))
                {
                    baseBrick.Data = levelData.Bricks[i].Data;
                }
#else
                go = Instantiate(levelData.Bricks[i].Data.Prefab, parent);
#endif

                if (go.TryGetComponent(out Brick brick))
                {
                    brick.Initialize(levelData.Bricks[i].Data as BreakableBrickData, onScorePointsKnockedOut);
                }
                else
                {
#if UNITY_EDITOR
                    baseBrick.Initialize(levelData.Bricks[i].Data);
#endif
                }

                go.transform.position = levelData.Bricks[i].Position;
            }
        }
    }
}
