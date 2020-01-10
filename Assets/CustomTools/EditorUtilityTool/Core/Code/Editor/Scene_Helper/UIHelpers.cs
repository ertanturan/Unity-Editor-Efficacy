﻿using UnityEditor;
using UnityEngine;

namespace EditorUtility.Core
{
    public static class UIHelpers
    {
        public static void CreateUIGroup()
        {
            GameObject selectedGO = EditorUtils.GetSelectedObject();
            GameObject uiGrp = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/CustomTools/EditorUtilityTool/UI/Prefabs/UI_GRP.prefab", typeof(GameObject));
            if (uiGrp)
            {
                GameObject curUIGrp = GameObject.Instantiate(uiGrp);
                curUIGrp.name = "UI_GRP";

                if (selectedGO)
                {
                    curUIGrp.transform.SetParent(selectedGO.transform);
                }
            }
            else
            {
                EditorUtils.DisplayDialogBox("Unable to Find the UI_GRP Prefab!");
            }
        }
    }
}
