using UnityEngine;

namespace MiniJameGam.Item
{
    public class SpawnerManager : MonoBehaviour
    {
        public static SpawnerManager Instance { private set; get; }

        [SerializeField]
        private GameObject[] _spawnables;

        private void Awake()
        {
            Instance = this;
        }

        public void Spawn()
        {

        }
    }
}
