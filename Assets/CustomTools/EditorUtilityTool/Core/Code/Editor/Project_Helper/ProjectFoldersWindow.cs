using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EditorUtility.Core
{
    public class ProjectFoldersWindow : BaseWindow
    {
        #region Variables
        static ProjectFoldersWindow m_Win;

        string m_wantedRootName = "Game";
        string m_dialogName = "Project Setup";
        #endregion

        #region Main Methods
        public static void InitWindow()
        {
            m_Win = GetWindow<ProjectFoldersWindow>(true, "Project Folders", true);
            m_Win.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Game Name: ", EditorStyles.boldLabel);
            m_wantedRootName = EditorGUILayout.TextField(m_wantedRootName);
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Create Folder Structure", GUILayout.ExpandWidth(true), GUILayout.Height(32)))
            {
                //Debug.Log(Application.dataPath);
                CreateRootFolder();
            }


            //Make sure we have the instance and repaint it
            if (m_Win)
            {
                m_Win.Repaint();
            }
        }
        #endregion

        #region Custom Methods
        private void CreateRootFolder()
        {
            if (m_wantedRootName == "" || m_wantedRootName == null)
            {
                DialogDisplay("Please Provide a Proper Game Name");
                return;
            }

            if (m_wantedRootName == "Game")
            {
                DialogDisplay("Do you really want to name this game..Game?");
                return;
            }

            Debug.Log("Creating Root Folder...");
            string assetFolder = Application.dataPath;
            string rootName = assetFolder + "/" + m_wantedRootName;

            DirectoryInfo rootInfo = Directory.CreateDirectory(rootName);

            if (!rootInfo.Exists)
            {
                return;
            }
            CreatSubDirectories(rootName);

            AssetDatabase.Refresh();

            if (m_Win)
            {
                m_Win.Close();
            }
        }

        private void CreatSubDirectories(string aRootFolder)
        {
            DirectoryInfo rootInfo = null;
            List<string> afolderList = new List<string>();

            rootInfo = Directory.CreateDirectory(aRootFolder + "/" + "Art");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Animation");
                afolderList.Add("Audio");
                afolderList.Add("Audio/Source");
                afolderList.Add("Audio/FX");
                afolderList.Add("Audio/Mixers");
                afolderList.Add("Fonts");
                afolderList.Add("Materials");
                afolderList.Add("Objects");
                afolderList.Add("Textures");

                CreateSubFolders(aRootFolder + "/" + "Art", afolderList);
            }

            rootInfo = Directory.CreateDirectory(aRootFolder + "/" + "Code");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Editor");
                afolderList.Add("Editor/Abstracts");
                afolderList.Add("Scripts");
                afolderList.Add("Scripts/Abstracts");
                afolderList.Add("Scripts/Enumeration");
                afolderList.Add("Scripts/Scriptable Objects");
                afolderList.Add("Scripts/Audio");
                afolderList.Add("Scripts/UI");
                afolderList.Add("Scripts/Features");
                afolderList.Add("Scripts/Gameplay");
                afolderList.Add("Scripts/Input");
                afolderList.Add("Shaders");
                afolderList.Add("Tests");
                CreateSubFolders(aRootFolder + "/" + "Code", afolderList);
            }

            rootInfo = Directory.CreateDirectory(aRootFolder + "/" + "Resources");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Data");
                afolderList.Add("Characters");
                afolderList.Add("Managers");
                afolderList.Add("Props");
                afolderList.Add("UI");
                CreateSubFolders(aRootFolder + "/" + "Resources", afolderList);
            }

            rootInfo = Directory.CreateDirectory(aRootFolder + "/" + "Prefabs");
            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Characters");
                afolderList.Add("Props");
                afolderList.Add("UI");
                afolderList.Add("Environment");
                afolderList.Add("Level");
                CreateSubFolders(aRootFolder + "/" + "Prefabs", afolderList);
            }

            rootInfo = Directory.CreateDirectory(aRootFolder + "/" + "Utilities");


            if (rootInfo.Exists)
            {
                afolderList.Clear();
                afolderList.Add("Sprite Atlas");
                CreateSubFolders(aRootFolder + "/" + "Utilities", afolderList);
            }



            DirectoryInfo sceneDir = Directory.CreateDirectory(aRootFolder + "/" + "Scenes");
            //Debug.Log(sceneDir.FullName);

            //Create the Base Level Scenes needed for a simple game
            Scene curFrontendScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(curFrontendScene, "Assets/" + m_wantedRootName + "/Scenes/" + m_wantedRootName + "_Frontend.unity", true);

            Scene curMainScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(curMainScene, "Assets/" + m_wantedRootName + "/Scenes/" + m_wantedRootName + "_Main.unity", true);

            Scene curStartupScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(curStartupScene, "Assets/" + m_wantedRootName + "/Scenes/" + m_wantedRootName + "_Startup.unity", true);

        }

        private void CreateSubFolders(string aRootFolder, List<string> subFolders)
        {
            foreach (string aFolder in subFolders)
            {
                Directory.CreateDirectory(aRootFolder + "/" + aFolder);
            }
        }

        private void DialogDisplay(string aMessage)
        {
            UnityEditor.EditorUtility.DisplayDialog(m_dialogName + "Warning", aMessage, "OK");
        }
        #endregion
    }
}
