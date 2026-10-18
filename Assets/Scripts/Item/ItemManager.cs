using System.Collections.Generic;
using UnityEngine;

namespace MiniJameGam.Item
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager Instance { private set; get; }

        private readonly Dictionary<ResourceType, int> _inventory = new();

        private void Awake()
        {
            Instance = this;
        }

        public void Add(ResourceType type, int count)
        {
            if (_inventory.ContainsKey(type))
            {
                _inventory[type] += count;
            }
            else
            {
                _inventory.Add(type, count);
            }
        }

        public void Remove(ResourceType type, int count)
        {
            _inventory[type] -= count;
        }

        public int Count(ResourceType type)
        {
            if (_inventory.TryGetValue(type, out int count)) return count;
            return 0;
        }
    }
}
