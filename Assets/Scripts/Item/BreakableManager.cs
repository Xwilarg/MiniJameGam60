using System.Collections.Generic;
using UnityEngine;

namespace MiniJameGam.Item
{
    public class BreakableManager : MonoBehaviour
    {
        public static BreakableManager Instance { private set; get; }

        [SerializeField]
        private Dictionary<ResourceType, GameObject[]> _resources;

        private void Awake()
        {
            Instance = this;
        }

        public void SpawnResource(ResourceType resource, Vector3 point)
        {
            var possibles = _resources[resource];
            Instantiate(possibles[Random.Range(0, possibles.Length)], point + Random.insideUnitSphere, Random.rotation);
        }
    }
}
