using MiniJameGam.SO;
using UnityEngine;

namespace MiniJameGam.Item
{
    public class CraftingManager : MonoBehaviour
    {
        public CraftingManager Instance { private set; get; }

        [SerializeField]
        private RecipeInfo[] _recipes;

        private void Awake()
        {
            Instance = this;
        }
    }
}
