using UnityEditor;
using UnityEngine;

namespace EditorUtility.Core
{
    [CustomEditor(typeof(MouseInput))]
    public class MouseInputEditor : Editor
    {
        #region Variables
        MouseInput targetInput;
        #endregion


        #region Main Methods
        void OnEnable()
        {
            targetInput = (MouseInput)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(20f);

            //Gather the Debug information for the Mouse
            string mouseInfo = "";
            mouseInfo += "Mouse Position: " + targetInput.MousePostion.ToString() + "\n";
            mouseInfo += "Mouse Delta: " + targetInput.MouseDelta.ToString() + "\n";
            mouseInfo += "Zoom Delta: " + targetInput.ZoomDelta.ToString() + "\n";
            mouseInfo += "\n";
            mouseInfo += "Left Button Down: " + targetInput.LeftMouseButton.ButtonDown.ToString() + "\n";
            mouseInfo += "Left Button Held: " + targetInput.LeftMouseButton.ButtonHeld.ToString() + "\n";
            mouseInfo += "Left Button Up: " + targetInput.LeftMouseButton.ButtonUp.ToString() + "\n";
            mouseInfo += "\n";
            mouseInfo += "Middle Button Down: " + targetInput.MiddleMouseButton.ButtonDown.ToString() + "\n";
            mouseInfo += "Middle Button Held: " + targetInput.MiddleMouseButton.ButtonHeld.ToString() + "\n";
            mouseInfo += "Middle Button Up: " + targetInput.MiddleMouseButton.ButtonUp.ToString() + "\n";
            mouseInfo += "\n";
            mouseInfo += "Right Button Down: " + targetInput.RightmouseButton.ButtonDown.ToString() + "\n";
            mouseInfo += "Right Button Held: " + targetInput.RightmouseButton.ButtonHeld.ToString() + "\n";
            mouseInfo += "Right Button Up: " + targetInput.RightmouseButton.ButtonUp.ToString() + "\n";

            //Display the Debug Information
            EditorGUILayout.TextArea(mouseInfo, GUILayout.ExpandWidth(true), GUILayout.Height(210));

            GUILayout.Space(20f);

            Repaint();
        }
        #endregion
    }
}
