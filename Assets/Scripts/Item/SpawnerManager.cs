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

        private const int MaxObjectCount = 7;
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
                yield return new WaitForSeconds(Random.Range(.5f, 2f));
            }
        }

        public void Spawn()
        {
            var go = Instantiate(_spawnables[Random.Range(0, _spawnables.Length)], _spawnPoint.position, Random.rotation);
            var vel = Random.insideUnitSphere * 10f;
            vel.y = 0f;
            go.GetComponent<Rigidbody>().linearVelocity = vel;
            ActiveObjectCount++;
        }

        public void StartAutoSpawn()
        {
            StartCoroutine(SpawnObjects());
        }
    }
}
