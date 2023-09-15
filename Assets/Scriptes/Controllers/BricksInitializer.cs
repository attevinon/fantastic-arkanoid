using System.Collections.Generic;
using UnityEngine;
using FantasticArkanoid.Scriptable;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FantasticArkanoid
{
    public class BricksInitializer
    {
        public void InitializeBricks(LevelStaticData levelData, Transform parent)
        {
            for (int i = 0; i < levelData.Bricks.Count; i++)
            {
#if UNITY_EDITOR
                GameObject goEditor;

                goEditor = PrefabUtility.InstantiatePrefab(levelData.Bricks[i].Data.Prefab, parent) as GameObject;

                if (goEditor.TryGetComponent(out Brick brickInEditor))
                {
                    brickInEditor.Data = levelData.Bricks[i].Data;
                    brickInEditor.Initialize(levelData.Bricks[i].Data as BreakableBrickData);
                }

#else
                GameObject go = Instantiate(levelData.Bricks[i].Data.Prefab, parent);

                if (go.TryGetComponent(out Brick brick))
                {
                    BreakableBrickData breakableBrickData = levelData.Bricks[i].Data as BreakableBrickData;
                    brick.Initialize(breakableBrickData);
                }

                go.transform.position = levelData.Bricks[i].Position;

#endif
            }
        }
    }
}
