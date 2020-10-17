using UnityEditor;
using UnityEngine;

namespace EditorUtility.Core
{
    public class DesignerDashWindow : EditorWindow
    {
        #region Variables
        public static GUISkin editorSkin;
        #endregion

        #region Methods
        public static void InitDesignerDashboard()
        {
            var win = EditorWindow.GetWindow<DesignerDashWindow>();
            win.titleContent = new GUIContent("Designer Dashboard");
            win.Show();

            editorSkin = EditorUtils.GetEditorUI();
        }

        void Update()
        {
            if (!editorSkin)
            {
                editorSkin = EditorUtils.GetEditorUI();
            }
        }

        void OnGUI()
        {
            Rect headerRect = EditorGUILayout.BeginVertical(editorSkin.GetStyle("bg"), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            EditorGUILayout.EndVertical();


            GUI.Box(new Rect(0f, 0f, headerRect.width, 70f), "", editorSkin.box);
            //            GUILayout.Box("", editorSkin.box, GUILayout.ExpandWidth(true), GUILayout.Height(70f));
            GUI.Label(new Rect(15f, 35f, headerRect.width, 100f), "Designer Dashboard", editorSkin.GetStyle("h1"));


            GUI.BeginGroup(new Rect(0f, 78f, headerRect.width, 300f));
            GUI.Box(new Rect(0f, 0f, headerRect.width, 300f), "", editorSkin.box);
            GUI.Label(new Rect(25f, 15f, 100f, 100f), "Label");
            GUI.EndGroup();


            if (Event.current.type == EventType.Repaint)
            {
                Repaint();
            }

        }
        #endregion
    }
}
