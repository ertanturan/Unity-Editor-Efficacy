using UnityEditor;
using UnityEngine;

namespace EditorUtility.Core
{
    public class BaseWindow : EditorWindow
    {
        #region Variables
        protected GameObject[] m_SelectedObjects = new GameObject[0];
        #endregion

        #region Methods
        protected virtual void GetSelected()
        {
            m_SelectedObjects = Selection.gameObjects;
        }
        #endregion
    }
}
