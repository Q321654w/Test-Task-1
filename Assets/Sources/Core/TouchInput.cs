using UnityEngine;

namespace Sources.Core
{
    internal class TouchInput : IInputSafe<Vector2>
    {
        public bool HasNext()
        {
            return Input.GetMouseButtonDown(0);
        }

        public Vector2 Read()
        {
#if UNITY_IPHONE || UNITY_ANDROID           
            return Input.touches[0].position;
#else
            return Input.mousePosition;
#endif
        }
    }
}