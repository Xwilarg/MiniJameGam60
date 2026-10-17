using System.Collections;
using UnityEngine;

namespace MiniJameGam.Item
{
    public class SpawnerManager : MonoBehaviour
    {
        public static SpawnerManager Instance { private set; get; }

        [SerializeField]
        private GameObject[] _spawnables;

        [SerializeField]
        private Transform _spawnPoint;

        private const int MaxObjectCount = 5;
        public int ActiveObjectCount { set; get; }

        private void Awake()
        {
            Instance = this;
        }

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                if (ActiveObjectCount < MaxObjectCount) Spawn();
                yield return new WaitForSeconds(Random.Range(.5f, 3f));
            }
        }

        public void Spawn()
        {
            Instantiate(_spawnables[Random.Range(0, _spawnables.Length)], _spawnPoint.position, Random.rotation);
            ActiveObjectCount++;
        }

        public void StartAutoSpawn()
        {
            StartCoroutine(SpawnObjects());
        }
    }
}
