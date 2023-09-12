using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid.Components
{
    public class SpawnerComponent : MonoBehaviour
    {
        [SerializeField] public GameObject PrefabToSpawn;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _parent;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var go = Instantiate(PrefabToSpawn, _spawnPosition.position, Quaternion.identity);
            go.SetActive(true);
        }

        [ContextMenu("SpawnWithParent")]
        public void SpawnWithParent()
        {
            var go = Instantiate(PrefabToSpawn, _spawnPosition.position, Quaternion.identity, _parent);
            go.SetActive(true);
        }
    }
}
