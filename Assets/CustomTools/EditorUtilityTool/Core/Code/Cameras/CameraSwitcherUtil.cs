using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorUtility.Core
{
    public class CameraSwitcherUtil : MonoBehaviour
    {
        #region Variables
        [Header("Switcher Properties")]
        public float SwitchTime = 2f;

        private List<Camera> _cameras = new List<Camera>();
        private int _currentCameraID;
        private float _lastSwitchTime = 0f;
        #endregion

        #region BuiltIn Methods
        // Use this for initialization
        void Start()
        {
            _cameras = gameObject.GetComponentsInChildren<Camera>().ToList<Camera>();
            _currentCameraID = 0;
            SwitchCamera();
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time >= _lastSwitchTime + SwitchTime)
            {
                _currentCameraID++;
                if (_currentCameraID >= _cameras.Count)
                {
                    _currentCameraID = 0;
                }

                SwitchCamera();
            }
        }
        #endregion

        #region Custom Methods
        void SwitchCamera()
        {
            for (int i = 0; i < _cameras.Count; i++)
            {
                _cameras[i].gameObject.SetActive(false);
            }
            _cameras[_currentCameraID].gameObject.SetActive(true);

            _lastSwitchTime = Time.time;
        }
        #endregion
    }
}
