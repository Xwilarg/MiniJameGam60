using System.Collections.Generic;
using UnityEngine;

namespace MiniJameGam.Item
{
    public class BreakableItem : MonoBehaviour
    {
        [SerializeField]
        private Dictionary<ResourceType, int> _resources;

        private int _health = 5;

        public void Hit(int damage)
        {
            _health -= damage;
            if (_health <= 0f)
            {
                foreach (var r in _resources)
                {
                    for (int i = 0; i < r.Value; i++)
                    {
                        BreakableManager.Instance.SpawnResource(r.Key, transform.position);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
}
