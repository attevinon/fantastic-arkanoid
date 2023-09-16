using FantasticArkanoid.Utilites;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class SaveLevel
    {
        public List<BrickOnLevel> GetBricks()
        {
            var bricks = new List<BrickOnLevel>();
            GameObject[] allBricks = GameObject.FindGameObjectsWithTag(ConstStrings.Tags.BRICK_TAG);

            foreach (var item in allBricks)
            {
                BrickOnLevel brickOnLevel = new BrickOnLevel();

                if(item.TryGetComponent(out BaseBrick baseBrick))
                {
                    brickOnLevel.Data = baseBrick.Data;
                    brickOnLevel.Position = baseBrick.transform.position;
                }

                bricks.Add(brickOnLevel);
            }

            return bricks;
        }
    }
}
