using System;
using System.Collections.Generic;
using UnityEngine;
using FantasticArkanoid.Scriptable;

namespace FantasticArkanoid
{
    [CreateAssetMenu(fileName = "EditorData", menuName = "EditorData/Data")]
    public class EditorData : ScriptableObject
    {
        public List<EditorBrickData> BrickData = new List<EditorBrickData>();
    }

    [Serializable]
    public class EditorBrickData
    {
        public Texture2D Texture2D;
        public BrickData BrickData;
    }
}
