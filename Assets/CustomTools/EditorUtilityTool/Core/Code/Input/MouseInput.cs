using UnityEngine;
using UnityEngine.Events;

namespace EditorUtility.Core
{
    public class MouseInput : MonoBehaviour
    {
        #region Variables
        public MouseButtonInfo LeftMouseButton = new MouseButtonInfo();
        public MouseButtonInfo MiddleMouseButton = new MouseButtonInfo();
        public MouseButtonInfo RightmouseButton = new MouseButtonInfo();

        private Vector2 _mousePosition;
        public Vector2 MousePostion
        {
            get { return _mousePosition; }
        }

        private Vector2 _mouseDelta;
        public Vector2 MouseDelta
        {
            get { return _mouseDelta; }
        }

        private float _zoomDelta;
        public float ZoomDelta
        {
            get { return _zoomDelta; }
        }

        [Header("Mouse Events")]
        public UnityEvent OnLeftButtonDown = new UnityEvent();
        public UnityEvent OnLeftButtonUp = new UnityEvent();

        public UnityEvent OnMiddleButtonDown = new UnityEvent();
        public UnityEvent OnMiddleButtonUp = new UnityEvent();

        public UnityEvent OnRightButtonDown = new UnityEvent();
        public UnityEvent OnRightButtonUp = new UnityEvent();
        #endregion

        #region Main Methods
        // Use this for initialization
        private void Start()
        {
            InitializeInputs();
        }

        // Update is called once per frame
        private void Update()
        {
            HandleButtonEvents();
            HandleMousePositionData();
        }
        #endregion

        #region Custom Methods
        protected virtual void InitializeInputs() { }

        protected virtual void HandleButtonEvents()
        {
            //Left Mouse Button Events
            LeftMouseButton.ButtonDown = Input.GetMouseButtonDown(0);
            LeftMouseButton.ButtonHeld = Input.GetMouseButton(0);
            LeftMouseButton.ButtonUp = Input.GetMouseButtonUp(0);

            if (OnLeftButtonDown != null && LeftMouseButton.ButtonDown)
            {
                OnLeftButtonDown.Invoke();
            }

            if (OnLeftButtonDown != null && LeftMouseButton.ButtonUp)
            {
                OnLeftButtonUp.Invoke();
            }



            //Middle Mouse Button Events
            MiddleMouseButton.ButtonDown = Input.GetMouseButtonDown(2);
            MiddleMouseButton.ButtonHeld = Input.GetMouseButton(2);
            MiddleMouseButton.ButtonUp = Input.GetMouseButtonUp(2);
            _zoomDelta = Input.GetAxis("Mouse ScrollWheel");

            if (OnMiddleButtonDown != null && MiddleMouseButton.ButtonDown)
            {
                OnMiddleButtonDown.Invoke();
            }

            if (OnMiddleButtonUp != null && MiddleMouseButton.ButtonUp)
            {
                OnMiddleButtonUp.Invoke();
            }



            //Right Mouse Button Events
            RightmouseButton.ButtonDown = Input.GetMouseButtonDown(1);
            RightmouseButton.ButtonHeld = Input.GetMouseButton(1);
            RightmouseButton.ButtonUp = Input.GetMouseButtonUp(1);

            if (OnRightButtonDown != null && RightmouseButton.ButtonDown)
            {
                OnRightButtonDown.Invoke();
            }

            if (OnRightButtonUp != null && RightmouseButton.ButtonUp)
            {
                OnRightButtonUp.Invoke();
            }
        }

        protected virtual void HandleMousePositionData()
        {
            _mousePosition = Input.mousePosition;
            _mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
        #endregion
    }


    #region Button Info Struct
    public struct MouseButtonInfo
    {
        public bool ButtonDown;
        public bool ButtonHeld;
        public bool ButtonUp;
    }
    #endregion
}
