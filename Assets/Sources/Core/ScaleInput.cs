using UnityEngine;

namespace Sources.Core
{
    public class ScaleInput : MonoBehaviour, IInput<float>
    {
        private Vector2 _finger1Position;
        private Vector2 _finger2Position;

        private float _scalingFactor = 1f;
        private float _previousDistance = 0f;

        private void Update()
        {
            if (Input.touchCount != 2)
            {
                _previousDistance = 0f;
                return;
            }


            Touch finger1 = Input.GetTouch(0);
            Touch finger2 = Input.GetTouch(1);


            _finger1Position = finger1.position;
            _finger2Position = finger2.position;


            float currentDistance = Vector2.Distance(finger1.position, finger2.position);

            if (_previousDistance == 0)
            {
                _previousDistance = currentDistance;
                return;
            }

            _scalingFactor *= currentDistance / _previousDistance;
            _previousDistance = currentDistance;
        }

        public float Read()
        {
            return _scalingFactor;
        }
    }
}