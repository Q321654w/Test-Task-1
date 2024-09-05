using UnityEngine;

namespace Sources.Core
{
    public class RotationInput : MonoBehaviour, IInput<Vector3>
    {
        private Vector2 _finger1Position;
        private Vector2 _finger2Position;

        private float _initialAngle;
        private float _rotationAngle;

        private void Update()
        {
            if (Input.touchCount != 2)
            {
                _initialAngle = 0f;
                return;
            }

            Touch finger1 = Input.GetTouch(0);
            Touch finger2 = Input.GetTouch(1);


            _finger1Position = finger1.position;
            _finger2Position = finger2.position;


            Vector2 direction = finger2.position - finger1.position;


            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


            if (_initialAngle == 0f)
            {
                _initialAngle = angle;
                return;
            }


            _rotationAngle = angle - _initialAngle;
            _initialAngle = angle;
        }

        public Vector3 Read()
        {
            return new Vector3(0, _initialAngle, 0);
        }
    }
}