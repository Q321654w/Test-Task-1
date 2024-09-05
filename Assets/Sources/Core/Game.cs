using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameArea _area;
        [SerializeField] private List<Figure> _figures;
        [SerializeField] private ScaleInput _scaleInput;
        [SerializeField] private RotationInput _rotationInput;
        [SerializeField] private Camera _camera;
        private IInputSafe<Vector2> _touchInput;

        private Figure _figure;

        private void Awake()
        {
            var touchInput = new TouchInput();
            Init(_area, _figures, touchInput, _scaleInput, _rotationInput);
            
            foreach (var figure in _figures)
            {
                figure.Init(_area);
            }
        }

        public void Init(GameArea area, List<Figure> figures, IInputSafe<Vector2> touchInput,
            ScaleInput scaleInput,
            RotationInput rotationInput)
        {
            _area = area;
            _figures = figures;
            _touchInput = touchInput;
            _scaleInput = scaleInput;
            _rotationInput = rotationInput;
            _figure = null;
        }


        private void Update()
        {
            ControlFigureSelection();
            ControlEnvironmentTransformation();
        }

        private void ControlEnvironmentTransformation()
        {
            var angle = _rotationInput.Read();
            var scaleFactor = _scaleInput.Read();

            if (scaleFactor != 0 && Math.Abs(scaleFactor - 1) > 0.0001f)
                _area.transform.localScale = new Vector3(scaleFactor, 0, scaleFactor);

            if (angle != Vector3.zero)
                _area.transform.rotation *= Quaternion.Euler(angle);
        }

        private void ControlFigureSelection()
        {
            if (!_touchInput.HasNext())
                return;

            var touchCoordinates = _touchInput.Read();
            var ray = _camera.ScreenPointToRay(touchCoordinates);
            Physics.Raycast(ray, out var hit);
            var hitCoordinates = _area.CoordinatesToCellCoordinates(hit.point);
            var coordinates = new Vector2(hitCoordinates.x, hitCoordinates.z);
            
#if DEBUG
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);
#endif

            if (_figure != null)
            {
                _figure.MoveTo(coordinates);
                _figure = null;
                return;
            }

            if (hit.collider.gameObject.TryGetComponent<Figure>(out var figure))
                _figure = figure;
        }
    }
}