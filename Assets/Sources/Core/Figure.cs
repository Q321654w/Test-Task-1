using UnityEngine;

namespace Sources.Core
{
    public class Figure : MonoBehaviour
    {
        private GameArea _gameArea;

        public void Init(GameArea gameArea)
        {
            _gameArea = gameArea;
        }

        public void MoveTo(Vector2 coordinates)
        {
            transform.position = new Vector3(coordinates.x, transform.position.y, coordinates.y);
        }

        public Vector2 Coordinates()
        {
            var position = transform.position;
            return new Vector2(position.x,position.z);
        }
    }
}