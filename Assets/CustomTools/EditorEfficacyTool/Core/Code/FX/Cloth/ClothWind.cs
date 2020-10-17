using UnityEngine;

namespace EditorUtility.Core
{
    [RequireComponent(typeof(Cloth))]
    public class ClothWind : MonoBehaviour
    {
        #region Variables
        public WindZone WindZone;

        private Cloth _clothComponent;
        #endregion

        #region Main Methods
        // Use this for initialization
        private void Start()
        {
            _clothComponent = GetComponent<Cloth>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (WindZone && _clothComponent)
            {
                var randPos = Mathf.Abs(Mathf.Sin(Time.time * transform.position.x) * Time.deltaTime * 10f);
                _clothComponent.externalAcceleration = (WindZone.transform.forward * WindZone.windPulseMagnitude * WindZone.windTurbulence) * (WindZone.windMain * Mathf.Abs(Mathf.Sin(Time.time)) * randPos);
            }
        }
        #endregion
    }
}
