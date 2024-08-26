using UnityEditor;
using UnityEngine;
using FantasticArkanoid.Scriptable;
using FantasticArkanoid.Level;

namespace FantasticArkanoid
{
    public class LevelEditor : EditorWindow
    {
        private Transform _parent;
        private EditorData _data;
        private int _selectedBrickIndex = 0;
        private LevelStaticData _levelData;
        private SceneEditor _sceneEditor;
        private bool _isEditionEnabled;
        private bool _isEditionEnabledOnce;

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
                    _sceneEditor.Initialize(_parent, GetSelectedBrick);
                }
            }
            else
            {
                if (GUILayout.Button("Clear Keys"))
                {
                    LevelsProgressDataAccess progressesDataAccess = new LevelsProgressDataAccess();
                    progressesDataAccess.ClearData();
                }

                GUILayout.Space(5);

                if (GUILayout.Button("Clear Data"))
                {
                    SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
                    _isEditionEnabledOnce = false;
                    _sceneEditor = null;
                    _data = null;
                }

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
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                _isEditionEnabled = GUILayout.Toggle(_isEditionEnabled, "Edition Mode");
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                if (_isEditionEnabled)
                {
                    if (!_isEditionEnabledOnce)
                    {
                        SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
                        _isEditionEnabledOnce = true;
                    }

                    GUILayout.Label("Adding a brick: LMB.");
                    GUILayout.Label("Deleting the brick: alt + LMB");

                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUI.color = Color.red;
                    if (GUILayout.Button("Clear Level"))
                    {
                        LevelCleaner levelCleaner = FindObjectOfType<LevelCleaner>();
                        levelCleaner.CleanLevel();
                    }
                    GUI.color = Color.white;
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                }
                else
                {
                    SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
                    _isEditionEnabledOnce = false;
                }

                GUI.color = Color.white;
                GUILayout.Space(30);

                //level
                _levelData = EditorGUILayout.ObjectField(_levelData, typeof(LevelStaticData), false) as LevelStaticData;
                GUILayout.Space(10);
                //level edition
                GUILayout.BeginHorizontal();

                if (GUILayout.Button("Load Level Data"))
                {
                    LevelCleaner levelCleaner = FindObjectOfType<LevelCleaner>();
                    levelCleaner.CleanLevel();

                    BricksInitializer bricksInitializer = new BricksInitializer();
                    bricksInitializer.InitializeBricks(_levelData, _parent, FindObjectOfType<ScoreCounter>().UpdateScore);
                }

                if (GUILayout.Button("Save Level Data"))
                {
                    SaveLevel saveLevel = new SaveLevel();
                    saveLevel.Save(_levelData);
                    EditorUtility.SetDirty(_levelData);
                    Debug.Log("level saved");
                }

                GUILayout.EndHorizontal();
                GUILayout.Space(10);
            }
        }
    }
}
