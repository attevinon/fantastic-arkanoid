using FantasticArkanoid.Scriptable;
using UnityEditor;
using UnityEngine;

namespace FantasticArkanoid
{
    public class SceneEditor : EditorWindow
    {
        private readonly EditorLevelGrid _grid = new EditorLevelGrid();
        private LevelEditor _levelEditor;
        private Transform _parent;

        public void Initialize(LevelEditor levelEditor, Transform parent)
        {
            _parent = parent;
            _levelEditor = levelEditor;
        }

        public void OnSceneGUI(SceneView sceneView)
        {
            _grid.DrawGrid();

            Event current = Event.current;

            if (current.type == EventType.Layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
            }

            if (current.type != EventType.MouseDown)
            {
                return;
            }

                Vector3 point = sceneView.camera.ScreenToWorldPoint(new Vector3(
                current.mousePosition.x, 
                sceneView.camera.pixelHeight - current.mousePosition.y,
                sceneView.camera.nearClipPlane));

            Vector3 brickPosition = _grid.CheckPosition(point);

            if(brickPosition == Vector3.zero)
            {
                return;
            }

            if (!IsEmpty(brickPosition))
            {
                Debug.LogWarning("Cell is occuped!");
                return;
            }

            GameObject go = PrefabUtility.InstantiatePrefab(_levelEditor.GetSelectedBrick().Prefab, _parent) as GameObject;
            go.transform.position = brickPosition;
             
            if(go.TryGetComponent(out Brick brick))
            {
                brick.Data = _levelEditor.GetSelectedBrick();
                brick.Initialize(_levelEditor.GetSelectedBrick() as BreakableBrickData);
            }

        }

        private bool IsEmpty(Vector3 position)
        {
            Collider2D collision = Physics2D.OverlapCircle(position, 0.1f);
            return collision == null;
        }
    }
}
