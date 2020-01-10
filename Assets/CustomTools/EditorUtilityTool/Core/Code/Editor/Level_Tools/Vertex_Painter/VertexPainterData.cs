using System;
using UnityEngine;

namespace EditorUtility.Core
{
    #region Structs
    [Serializable]
    public struct MouseData
    {
        public Vector2 mousePos;
        public bool leftClickHold;
        public bool leftClick;
        public bool rightClick;
        public bool rightClickHold;
        public Vector2 mouseDelta;
    };

    [Serializable]
    public struct BrushData
    {
        public float brushSize;
        public float falloffSize;
        public float opacity;
        public float sculptIntensity;
        public float startHeight;
        public Color brushColor;
        public SculptState sculptState;
        public int sculptDir;

        public BrushData(float aSize, float aFalloff, float anOpacity,
            Color aColor, SculptState aSculptState, float aIntensity, int aSculptDir,
            float aStartHeight)
        {
            brushSize = aSize;
            falloffSize = aFalloff;
            opacity = anOpacity;
            startHeight = aStartHeight;
            sculptIntensity = aIntensity;
            sculptDir = aSculptDir;
            brushColor = aColor;
            sculptState = aSculptState;
        }
    };
    #endregion


    #region Enums
    public enum SculptState
    {
        NormalDir = 0,
        WorldUpDir = 1,
        Flatten = 2,
    }

    public enum VTXPainterState
    {
        None = 0,
        Painting = 1,
        Sculpting = 2,
        Instancing = 3,
    }
    #endregion
}
