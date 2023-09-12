using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FantasticArkanoid.Scriptable;

namespace FantasticArkanoid
{
    public class BricksInitializer : MonoBehaviour
    {
        [SerializeField] private List<BreakableBrickData> _bricks;
        private void Start()
        {
            InitializeBricks();
        }
        public void InitializeBricks()
        {
            for (int i = 0; i < _bricks.Count; i++)
            {
                GameObject go = Instantiate(_bricks[i].Prefab, new Vector2(0 + i, 0), Quaternion.identity);
                if (go.TryGetComponent(out Brick brick))
                {
                    brick.Initialize(_bricks[i]);
                }
            }
        }
    }
}
