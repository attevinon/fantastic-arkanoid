using UnityEngine;

namespace FantasticArkanoid
{
    public class EditorLevelGrid
    {
        private const float LEFT_POSITION = -7.5f;
        private const float UP_POSITION = 4.25f;

        private const int COLUMNS_COUNT = 16;
        private const int ROWS_COUNT = 11;

        private const float CELL_HEIGHT = 0.5f;
        private const float CELL_WIDTH = 1f;

        public Vector3 CheckPosition(Vector3 position)
        {
            Vector3 tempPosition = Vector3.zero;

            float x = LEFT_POSITION - CELL_WIDTH / 2; //start x position = min X
            float y = UP_POSITION + CELL_HEIGHT / 2; //start y position = max Y

            //return zero vector if position is out of the grid
            if(position.x < x || position.x > (x + (CELL_WIDTH * COLUMNS_COUNT)) || 
                position.y > y || position.y < (y - (CELL_HEIGHT * ROWS_COUNT)))
            {
                Debug.LogWarning("Position is out of the play zone! position = " + position.x + ", " + position.y);
                return tempPosition;
            }

            //searching a row for the brick 
            for (int i = 0; i < COLUMNS_COUNT; i++)
            {
                if(position.x > x && position.x < x + CELL_WIDTH)
                {
                    tempPosition.x = x + CELL_WIDTH / 2;
                    break;
                }
                else
                {
                    x += CELL_WIDTH;
                }
            }

            //searching a column for the brick 
            for (int i = 0; i < ROWS_COUNT; i++)
            {
                if (position.y < y && position.y > y - CELL_HEIGHT)
                {
                    tempPosition.y = y - CELL_HEIGHT / 2;
                    break;
                }
                else
                {
                    y -= CELL_HEIGHT;
                }
            }

            return tempPosition;
        }
    }
}
