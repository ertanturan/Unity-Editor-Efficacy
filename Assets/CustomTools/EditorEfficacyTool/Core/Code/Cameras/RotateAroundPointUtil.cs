using UnityEngine;

namespace EditorUtility
{
    public class RotateAroundPointUtil : MonoBehaviour
    {
        #region Variables
        [Header("Utility Properties")]
        public Transform TargetTransform;
        [Range(0f, 360f)]
        public float StartAngle = 45f;
        public float RotationSpeed = 2f;
        public float Height = 2f;
        public float Distance = 2f;

        private Vector3 _wantedPosition;
        private Vector3 _finalPosition;

        private float _expectedAngle;
        private float _finalAngle;
        #endregion


        #region Main Methods
        // Use this for initialization
        void Start()
        {
            _expectedAngle = StartAngle;
            _finalAngle = _expectedAngle;
        }

        // Update is called once per frame
        void Update()
        {
            if (TargetTransform)
            {
                _wantedPosition = TargetTransform.position + (Vector3.forward * Distance);
                _expectedAngle += RotationSpeed * Time.deltaTime;
                _finalAngle = Mathf.Lerp(_finalAngle, _expectedAngle, Time.deltaTime * 2f);

                _wantedPosition = Quaternion.Euler(0f, _finalAngle, 0f) * _wantedPosition + (Vector3.up * Height);
                Debug.DrawLine(TargetTransform.position, _wantedPosition, Color.red);

                transform.position = _wantedPosition;
                transform.LookAt(TargetTransform);
            }
        }
        #endregion
    }
}
