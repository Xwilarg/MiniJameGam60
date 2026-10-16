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

        private void Awake()
        {
            Instance = this;
        }

        public void Spawn()
        {
            Instantiate(_spawnables[Random.Range(0, _spawnables.Length)], _spawnPoint.position, Random.rotation);
        }
    }
}
