using UnityEditor;
using UnityEngine;

namespace EditorUtility.Core
{
    public class ObjectReplacerWindow : BaseWindow
    {
        #region Variables
        static ObjectReplacerWindow m_Win;
        GameObject m_TargetObject;
        #endregion

        #region Main Methods
        public static void InitWindow()
        {
            m_Win = GetWindow<ObjectReplacerWindow>(true, "Object Replacer", true);
            m_Win.Show();
        }

        void OnEnable()
        {
            Selection.selectionChanged += GetSelected;
        }

        void OnDisable()
        {
            Selection.selectionChanged -= GetSelected;
        }
        #endregion


        #region UI Methods
        void OnGUI()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Selected Object Count: " + m_SelectedObjects.Length);
            m_TargetObject = (GameObject)EditorGUILayout.ObjectField("Target Object: ", m_TargetObject, typeof(GameObject), false);


            if (GUILayout.Button("Replace Selected", GUILayout.Height(44), GUILayout.ExpandWidth(true)))
            {
                ReplaceSelected();
            }

            Repaint();
        }

        void ReplaceSelected()
        {
            if (m_TargetObject && m_SelectedObjects.Length > 0)
            {
                for (int i = 0; i < m_SelectedObjects.Length; i++)
                {
                    GameObject oldGO = m_SelectedObjects[i];
                    GameObject newGO = Instantiate(m_TargetObject, oldGO.transform.position, oldGO.transform.rotation);
                    newGO.transform.localScale = oldGO.transform.localScale;

                    DestroyImmediate(oldGO);
                }
            }
            else
            {
                EditorUtils.DisplayDialogBox("Please Select Objects to replace or assign a GameObject to the target object!");
            }
        }
        #endregion
    }
}
