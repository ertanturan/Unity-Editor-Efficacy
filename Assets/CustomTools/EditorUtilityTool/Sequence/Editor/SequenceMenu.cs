using UnityEditor;
using UnityEngine;

namespace EditorUtility
{
    public static class SequenceMenu
    {
        [MenuItem("Editor Utility/Sequence/Create Sequence")]
        [MenuItem("GameObject/Editor-Utility/Create Sequence", false, 11)]
        public static void CreateGameSequence()
        {
            GameObject sequenceGO = new GameObject("New Sequence", typeof(GameSequence));
            sequenceGO.transform.position = Vector3.zero;
            Selection.activeGameObject = sequenceGO;
        }
    }
}
