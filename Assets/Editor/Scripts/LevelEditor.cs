using UnityEditor;
using UnityEngine;
using FantasticArkanoid.Scriptable;
using FantasticArkanoid.Utilites;

namespace FantasticArkanoid
{
    public class LevelEditor : EditorWindow
    {
        private Transform _parent;
        private EditorData _data;
        private int _selectedBrickIndex = 0;
        private bool _isEditionEnabled;
        private LevelStaticData _levelData;
        private SceneEditor _sceneEditor;

        [MenuItem("Window/Level Editor")]
        public static void Initialize()
        {
            LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
            levelEditor.Show();
        }
        public BrickData GetSelectedBrick()
        {
            return _data.BrickData[_selectedBrickIndex].BrickData;
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
                    _sceneEditor = CreateInstance<SceneEditor>();
                    _sceneEditor.Initialize(this, _parent);
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
                    _selectedBrickIndex--;
                    if (_selectedBrickIndex < 0)
                    {
                        _selectedBrickIndex = _data.BrickData.Count - 1;
                    }
                }
                GUILayout.FlexibleSpace();
                GUILayout.Label(_data.BrickData[_selectedBrickIndex].Texture2D);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    _selectedBrickIndex++;
                    if (_selectedBrickIndex > _data.BrickData.Count - 1)
                    {
                        _selectedBrickIndex = 0;
                    }
                }
                GUILayout.EndHorizontal();

                //show index of selected brick and total brick prefabs count
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label($"{_selectedBrickIndex + 1}/ {_data.BrickData.Count}", EditorStyles.boldLabel);
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
                if(GUILayout.Button("Add Bricks"))
                {
                    _isEditionEnabled = !_isEditionEnabled;

                    if (_isEditionEnabled)
                    {
                        SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
                    }
                    else
                    {
                        SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
                    }
                }
                GUI.color = Color.white;
                GUILayout.Space(30);

                //level
                _levelData = EditorGUILayout.ObjectField(_levelData, typeof(LevelStaticData), false) as LevelStaticData;
                GUILayout.Space(10);

                //level edition
                GUILayout.BeginHorizontal();

                if(GUILayout.Button("Load Level Data"))
                {
                    GameObject[] allBricks = GameObject.FindGameObjectsWithTag(ConstStrings.Tags.BRICK_TAG);
                    if(allBricks.Length != 0)
                    {
                        foreach (var brick in allBricks)
                        {
                            DestroyImmediate(brick.gameObject);
                        }
                    }

                    BricksInitializer bricksInitializer = new BricksInitializer();
                    bricksInitializer.InitializeBricks(_levelData, _parent);
                }

                if (GUILayout.Button("Save Level Data"))
                {
                    SaveLevel saveLevel = new SaveLevel();
                    _levelData.Bricks = saveLevel.GetBricks();
                    EditorUtility.SetDirty(_levelData);
                    Debug.Log("level saved");
                }

                GUILayout.EndHorizontal();
            }
        }
    }
}
