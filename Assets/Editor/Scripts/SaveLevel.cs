using FantasticArkanoid.Utilites;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    public class SaveLevel
    {
        public void Save(LevelStaticData level)
        {
            level.Bricks = new List<BrickOnLevel>();
            BaseBrick[] allBricks = GameObject.FindObjectsOfType<BaseBrick>();

            foreach (var brick in allBricks)
            {
                BrickOnLevel brickOnLevel = new BrickOnLevel() {
                    Data = brick.Data,
                    Position = brick.transform.position
                };

                level.Bricks.Add(brickOnLevel);
            }
        }
    }
}
