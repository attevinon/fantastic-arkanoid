using FantasticArkanoid.Utilites;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class SaveLevel
    {
        public List<BrickObject> GetBricks()
        {
            var bricks = new List<BrickObject>();
            GameObject[] allBricks = GameObject.FindGameObjectsWithTag(ConstStrings.Tags.BRICK_TAG);

            foreach (var item in allBricks)
            {
                BrickObject brickObject = new BrickObject();
                if (item.TryGetComponent(out Brick brick))
                {
                    brickObject.Data = brick.Data;
                    brickObject.Position = brick.transform.position;
                }

                bricks.Add(brickObject);
            }

            return bricks;
        }
    }
}
