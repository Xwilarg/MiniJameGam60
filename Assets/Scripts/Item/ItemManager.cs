using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MiniJameGam.Item
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager Instance { private set; get; }

        private readonly Dictionary<ResourceType, int> _inventory = new();

        [SerializeField]
        private Dictionary<ResourceType, TMP_Text> _textUIs;

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
            UpdateUI();
        }

        public void Remove(ResourceType type, int count)
        {
            _inventory[type] -= count;
            UpdateUI();
        }

        private void UpdateUI()
        {
            foreach (var r in _textUIs)
            {
                r.Value.text = Count(r.Key).ToString();
            }
        }

        public int Count(ResourceType type)
        {
            if (_inventory.TryGetValue(type, out int count)) return count;
            return 0;
        }
    }
}
