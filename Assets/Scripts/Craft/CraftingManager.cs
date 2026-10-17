using MiniJameGam.SO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiniJameGam.Craft
{
    public class CraftingManager : MonoBehaviour
    {
        public static CraftingManager Instance { private set; get; }

        [SerializeField]
        private List<RecipeInfo> _recipes;

        [SerializeField]
        private RecipeInfo _weaponRecipe;

        [SerializeField]
        private GameObject _cratingMenu, _craftingItem;

        [SerializeField]
        private RectTransform _craftingContainer;

        private readonly List<CraftingUI> _recipeUIs = new();

        public bool IsActive => _cratingMenu.activeInHierarchy;

        private int _weaponLevel = -1;
        public int Power => _weaponLevel + 1;

        private void Awake()
        {
            Instance = this;

            _cratingMenu.SetActive(false);
        }

        private void Start()
        {
            foreach (var recipe in _recipes)
            {
                AddRecipe(recipe, false);
            }
            AddRecipe(_weaponRecipe, true);
        }

        public void AddRecipes(IEnumerable<RecipeInfo> recipes)
        {
            foreach (var recipe in recipes)
            {
                AddRecipe(recipe, false);
            }
        }

        private void AddRecipe(RecipeInfo recipe, bool front)
        {
            var go = Instantiate(_craftingItem, _craftingContainer);
            var cui = go.GetComponent<CraftingUI>();
            cui.Recipe = recipe;
            if (front) _recipeUIs.Insert(0, cui);
            else _recipeUIs.Add(cui);
        }

        public int ProgressWeaponRecipe()
        {
            _weaponRecipe = _weaponRecipe.NextRecipe;
            Destroy(_recipeUIs.First().gameObject);
            _recipeUIs.RemoveAll(x => x.Recipe.Output == ItemType.Weapon);
            if (_weaponRecipe != null) AddRecipe(_weaponRecipe, true);

            OpenCraftingUI();

            _weaponLevel++;
            return _weaponLevel;
        }

        public void RemoveRecipe(EntityId id)
        {
            var elem = _recipeUIs.FindIndex(x => x.Recipe.GetEntityId() == id);
            Destroy(_recipeUIs[elem].gameObject);
            _recipeUIs.RemoveAt(elem);
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
