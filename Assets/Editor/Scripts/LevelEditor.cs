using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FantasticArkanoid
{
    public class LevelEditor : EditorWindow
    {
        private Transform _parent;
        private EditorData _data;
        private int _index = 0;
        private bool _isEditionEnabled;
        private LevelStaticData _level;

        [MenuItem("Window/Level Editor")]
        public static void Initialize()
        {
            LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
            levelEditor.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true); //?????
            EditorGUILayout.Space(30);

            //load editor data
            if (_data == null)
            {
                if (GUILayout.Button("Load Data"))
                {
                    _data = (EditorData)AssetDatabase.LoadAssetAtPath("Assets/Editor/Data/EditorData.asset", typeof(EditorData));
                }
            }
            else
            {
                //BRICKPREFAB header
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Brick Prefab", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                //select brick prefab
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    _index--;
                    if (_index < 0)
                    {
                        _index = _data.BrickData.Count - 1;
                    }
                }
                GUILayout.FlexibleSpace();
                GUILayout.Label(_data.BrickData[_index].Texture2D);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    _index++;
                    if (_index > _data.BrickData.Count - 1)
                    {
                        _index = 0;
                    }
                }
                GUILayout.EndHorizontal();

                //show index of selected brick and total brick prefabs count
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label($"{_index + 1}/ {_data.BrickData.Count}", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                //LEVEL EDITION header
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Level Edition", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                //enable and disable edition
                GUI.color = _isEditionEnabled ? Color.green : Color.white;
                if(GUILayout.Button("Edit Level"))
                {
                    _isEditionEnabled = !_isEditionEnabled;
                }
                GUI.color = Color.white;
                GUILayout.Space(30);

                //level
                _level = EditorGUILayout.ObjectField(_level, typeof(LevelStaticData), false) as LevelStaticData;
                GUILayout.Space(10);

                //level edition
                GUILayout.BeginHorizontal();

                if(GUILayout.Button("Load Level Data"))
                {
                    GameObject[] allBricks = GameObject.FindGameObjectsWithTag("Bricks");
                    if(allBricks.Length != 0)
                    {
                        foreach (var brick in allBricks)
                        {
                            Destroy(brick.gameObject);
                        }

                        BricksInitializer bricksInitializer = new BricksInitializer();
                        bricksInitializer.InitializeBricks(_level, _parent);
                    }
                }

                if (GUILayout.Button("Save Level Data"))
                {
                    SaveLevel saveLevel = new SaveLevel();
                    _level.Bricks = saveLevel.GetBricks();
                    Debug.Log("level saved");
                }

                GUILayout.EndHorizontal();
            }
        }
    }
}
