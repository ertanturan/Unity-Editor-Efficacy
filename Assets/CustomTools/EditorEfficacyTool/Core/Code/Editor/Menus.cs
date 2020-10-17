using UnityEditor;

namespace EditorUtility.Core
{
    public class Menus
    {

        #region Project Tools Menus
        [MenuItem("Editor Utility/Project Tools/Create Project Folders")]
        public static void CreateProjectFolders()
        {
            ProjectFoldersWindow.InitWindow();
        }
        #endregion

        #region Scene Helpers Menus
        [MenuItem("Editor Utility/Scene Tools/Create Game Manager")]
        public static void CreateGameManager()
        {
            SceneHelpers.CreateGameManager();
        }

        [MenuItem("GameObject/Editor-Utility/Create Game Manager", false, 11)]
        public static void ContextCreateGameManager()
        {
            SceneHelpers.CreateGameManager();
        }

        [MenuItem("Editor Utility/Scene Tools/Group Selected")]
        public static void GroupSelectedGameObjects()
        {
            GroupingWindow.InitWindow();
        }

        [MenuItem("GameObject/Editor-Utility/Grouping", false, 11)]
        public static void ContextGrouping()
        {
            GroupingWindow.InitWindow();
        }

        [MenuItem("Editor Utility/Scene Tools/Object Replacement")]
        public static void ReplaceSelectedGameObjects()
        {
            ObjectReplacerWindow.InitWindow();
        }

        [MenuItem("Editor Utility/Scene Tools/Create Level Group")]
        public static void CreateLevelController()
        {
            SceneHelpers.CreateLevelGroup();
        }

        [MenuItem("GameObject/Editor-Utility/Create Level Group", false, 11)]
        public static void ContextCreateLevelController()
        {
            SceneHelpers.CreateLevelGroup();
        }

        [MenuItem("Editor Utility/Scene Tools/Create Inputs")]
        public static void CreateInputs()
        {
            SceneHelpers.CreateInputs();
        }

        [MenuItem("GameObject/Editor-Utility/Create Global Input", false, 11)]
        public static void ContextCreateInputs()
        {
            SceneHelpers.CreateInputs();
        }
        #endregion

        #region Level Tools
        [MenuItem("Editor Utility/Level Tools/Export Selected to Single OBJ")]
        public static void ExportSelectedToOBJ()
        {
            OBJExport.ExportWholeSelectionToSingle();
        }

        [MenuItem("Editor Utility/Level Tools/Export Each Selected to OBJ")]
        public static void ExportAllToOBJ()
        {
            OBJExport.ExportEachSelectionToSingle();
        }
        #endregion

        #region UI Helpers
        [MenuItem("Editor Utility/UI Tools/Create UI Canvas Grp")]
        public static void CreateUICanvasGroup()
        {
            UIHelpers.CreateUIGroup();
        }
        #endregion

    }
}
