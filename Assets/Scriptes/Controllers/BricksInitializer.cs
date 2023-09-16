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

                if(goEditor.TryGetComponent(out BaseBrick baseBrickInEditor))
                {
                    baseBrickInEditor.Data = levelData.Bricks[i].Data;

                    if (goEditor.TryGetComponent(out Brick brickInEditor))
                    {
                        brickInEditor.Initialize(levelData.Bricks[i].Data as BreakableBrickData);
                    }
                    else
                    {
                        baseBrickInEditor.Initialize(levelData.Bricks[i].Data);
                    }
                }

                goEditor.transform.position = levelData.Bricks[i].Position;
#else
                GameObject go = Instantiate(levelData.Bricks[i].Data.Prefab, parent);

                if (go.TryGetComponent(out BaseBrick baseBrick))
                {
                    if(go.TryGetComponent(out Brick brick))
                    {
                        BreakableBrickData breakableBrickData = levelData.Bricks[i].Data as BreakableBrickData;
                        brick.Initialize(breakableBrickData);
                    }
                    else
                    {
                        BrickData brickData = levelData.Bricks[i].Data;
                        baseBrick.Initialize(brickData);
                    }
                }

                go.transform.position = levelData.Bricks[i].Position;
#endif
            }
        }
    }
}
