using MiniJameGam.SO;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace MiniJameGam.Craft
{
    public class CraftingManager : MonoBehaviour
    {
        public static CraftingManager Instance { private set; get; }

        [SerializeField]
        private RecipeInfo[] _recipes;

        [SerializeField]
        private GameObject _cratingMenu, _craftingItem;

        [SerializeField]
        private RectTransform _craftingContainer;

        private readonly List<CraftingUI> _recipeUIs = new();

        public bool IsActive => _cratingMenu.activeInHierarchy;

        private void Awake()
        {
            Instance = this;

            _cratingMenu.SetActive(false);
        }

        private void Start()
        {
            foreach (var recipe in _recipes)
            {
                var go = Instantiate(_craftingItem, _craftingContainer);
                var cui = go.GetComponent<CraftingUI>();
                cui.Recipe = recipe;
                _recipeUIs.Add(cui);
            }
        }

        public void OpenCraftingUI()
        {
            _cratingMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            foreach (var recipe in _recipeUIs)
            {
                recipe.CheckCanCraft();
            }
        }

        public void CloseCraftingUI()
        {
            _cratingMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
