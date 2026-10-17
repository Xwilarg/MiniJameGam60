using MiniJameGam.Craft;
using UnityEngine;

namespace MiniJameGam.Item
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }

        public bool CanMove => !CraftingManager.Instance.IsActive && !RocketManager.Instance.IsShowingEnding;
    }
}
