using System;
using UnityEditor;
using UnityEngine;
using FantasticArkanoid.Scriptable;
using Unity.VisualScripting;

namespace FantasticArkanoid
{
    public class SceneEditor : EditorWindow
    {
        private readonly EditorLevelGrid _grid = new EditorLevelGrid();

        private Transform _bricksParent;
        private Func<BrickData> _getSelectedBrick;

        public void Initialize(Transform parent, Func<BrickData> getSelectedBrick)
        {
            _bricksParent = parent;
            _getSelectedBrick = getSelectedBrick;
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

            if (current.alt)
            {
                DeleteBrick(brickPosition);
            }
            else
            {
                AddBrick(brickPosition);
            }
        }

        private bool AddBrick(Vector3 brickPosition)
        {
            if (!IsEmpty(brickPosition))
            {
                Debug.LogWarning("Cell is occuped!");
                return false;
            }

            Debug.Log(_getSelectedBrick == null);
            var data = _getSelectedBrick?.Invoke();
            GameObject go = PrefabUtility.InstantiatePrefab(data.Prefab, _bricksParent) as GameObject;
            go.transform.position = brickPosition;

            if (go.TryGetComponent(out BaseBrick baseBrick))
            {
                baseBrick.Data = _getSelectedBrick?.Invoke();

                if (go.TryGetComponent(out Brick brick))
                {
                    brick.Initialize(_getSelectedBrick?.Invoke() as BreakableBrickData, null);
                }
                else
                {
                    baseBrick.Initialize(_getSelectedBrick?.Invoke());
                }

                return true;
            }

            return false;
        }

        private bool DeleteBrick(Vector3 brickPosition)
        {
            if (IsEmpty(brickPosition))
            {
                Debug.LogWarning("Cell is empty!");
                return false;
            }

            GameObject collision = FindCollision2D(brickPosition).gameObject;
            if (collision.TryGetComponent(out BaseBrick brickToDelete))
            {
                DestroyImmediate(brickToDelete.gameObject);
                return true;
            }

            return false;

        }

        private Collider2D FindCollision2D(Vector3 position)
        {
            return Physics2D.OverlapCircle(position, 0.1f);
        }

        private bool IsEmpty(Vector3 position)
        {
            return FindCollision2D(position) == null;
        }
    }
}
