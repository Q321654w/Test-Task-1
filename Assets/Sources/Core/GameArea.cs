using UnityEngine;

namespace Sources.Core
{
    public class GameArea : MonoBehaviour
    {
        private readonly Vector2 _topLeftBound;
        private readonly Vector2 _bottomRightBound;

        public GameArea(Vector2 topLeftBound, Vector2 bottomRightBound)
        {
            _topLeftBound = topLeftBound;
            _bottomRightBound = bottomRightBound;
        }

        public bool IsInArea(Vector2 coordinates)
        {
            return coordinates.x > _topLeftBound.x &&
                   coordinates.y < _topLeftBound.y &&
                   coordinates.x < _bottomRightBound.x &&
                   coordinates.y > _bottomRightBound.y;
        }

        public Vector3 CoordinatesToCellCoordinates(Vector3 coordinates)
        {
            var x = Mathf.RoundToInt(coordinates.x);
            var y = coordinates.y;
            var z = Mathf.RoundToInt(coordinates.z);
            return new Vector3(x, y, z);
        }

        public void Scale(float factor)
        {
            transform.localScale *= factor;
        }

        public void Rotate(Quaternion angle)
        {
            transform.rotation *= angle;
        }
    }
}