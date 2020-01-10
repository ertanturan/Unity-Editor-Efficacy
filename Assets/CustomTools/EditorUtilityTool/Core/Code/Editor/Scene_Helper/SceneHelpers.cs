using UnityEditor;
using UnityEngine;
//using Emortal.Gameplay;


namespace EditorUtility.Core
{
    public static class SceneHelpers
    {
        #region Menu Methods
        /// <summary>
        /// Creates the level group.
        /// </summary>
        public static void CreateLevelGroup()
        {
            //Create the main Level Manager Group
            GameObject levelGrp = new GameObject("Level_Manager");
            //            levelGrp.AddComponent<IP_Level_Manager>();

            //Create the Sub groups to hold certain types of Objcets int he scene
            string[] groupNames = new string[] { "Lighting_GRP", "Geo_GRP", "FX_GRP", "Audio_GRP" };
            CreateLevelGroups(levelGrp.transform, groupNames);

            //Select the Level Manager
            Selection.activeGameObject = levelGrp;

        }

        public static void CreateGameManager()
        {
            //Create the main Level Manager Group
            GameObject gmGO = new GameObject("Game_Manager");
            gmGO.AddComponent<GameManager>();


            //Select the Level Manager
            Selection.activeGameObject = gmGO;

        }

        public static void CreateInputs()
        {
            //Create the main Level Manager Group
            GameObject inputGO = new GameObject("Input");
            inputGO.AddComponent<GlobalInput>();


            //Select the Level Manager
            Selection.activeGameObject = inputGO;

        }
        #endregion


        #region Utility Methods
        static void CreateLevelGroups(Transform levelManager, string[] groupNames)
        {
            if (levelManager && groupNames.Length > 0)
            {
                for (int i = 0; i < groupNames.Length; i++)
                {
                    GameObject curGroup = new GameObject(groupNames[i]);
                    curGroup.transform.SetParent(levelManager);
                }
            }
        }
        #endregion
    }
}
