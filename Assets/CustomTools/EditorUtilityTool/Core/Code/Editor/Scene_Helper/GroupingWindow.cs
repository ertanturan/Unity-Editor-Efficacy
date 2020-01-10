using UnityEditor;
using UnityEngine;

namespace EditorUtility.Core
{
    public class GroupingWindow : BaseWindow
    {
        #region Variables
        static GroupingWindow m_Win;
        private string m_GroupName = "Parent";
        #endregion


        #region Main Methods
        public static void InitWindow()
        {
            m_Win = GetWindow<GroupingWindow>(true, "Object Grouping", true);

            m_Win.Show();
        }

        void OnEnable()
        {
            Selection.selectionChanged += GetSelected;
        }

        void OnDestroy()
        {
            Selection.selectionChanged -= GetSelected;
        }


        void OnGUI()
        {
            m_GroupName = EditorGUILayout.TextField("Group Name: ", m_GroupName);

            if (GUILayout.Button("Group Selected", GUILayout.Height(60)))
            {
                GroupSelected();
            }

            if (GUILayout.Button("UnGroup Selection", GUILayout.Height(60)))
            {
                UnGroupSelection();
            }

            if (m_Win)
            {
                m_Win.Repaint();
            }
        }
        #endregion

        #region Custom Methods
        void GroupSelected()
        {
            if (m_SelectedObjects.Length == 0)
            {
                GetSelected();
            }

            Transform parentGO = new GameObject(m_GroupName).transform;
            parentGO.position = Vector3.zero;

            for (int i = 0; i < m_SelectedObjects.Length; i++)
            {
                Transform curTrans = m_SelectedObjects[i].transform;
                curTrans.SetParent(parentGO);
            }

            Selection.activeGameObject = parentGO.gameObject;
        }

        void UnGroupSelection()
        {
            Transform selected = Selection.activeGameObject.transform;

            if (selected)
            {
                selected.DetachChildren();
                DestroyImmediate(selected.gameObject);
            }
        }
        #endregion
    }
}
