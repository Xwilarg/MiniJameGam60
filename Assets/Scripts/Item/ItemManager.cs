using UnityEngine;

namespace MiniJameGam.Item
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }
    }
}
