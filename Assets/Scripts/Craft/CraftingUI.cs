using MiniJameGam.Item;
using MiniJameGam.Player;
using MiniJameGam.Progression;
using MiniJameGam.SO;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniJameGam.Craft
{
    public class CraftingUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _title, _description;

        [SerializeField]
        private Button _button;

        private bool _canCraft = false;

        private RecipeInfo _recipe;
        public RecipeInfo Recipe
        {
            set
            {
                _recipe = value;

                _title.text = _recipe.Name;
                CheckCanCraft();
            }
            get
            {
                return _recipe;
            }
        }

        public void CheckCanCraft()
        {
            _canCraft = true;

            List<string> ingredients = new();

            foreach (var res in _recipe.Resources)
            {
                if (ItemManager.Instance.Count(res.Key) >= res.Value)
                {
                    ingredients.Add($"<color=green>{res.Key} x{res.Value}</color>");
                }
                else
                {
                    ingredients.Add($"<color=grey>{res.Key} x{res.Value}</color>");
                    _canCraft = false;
                }
            }

            _description.text = string.Join(", ", ingredients);
            _button.interactable = _canCraft;
        }

        public void Craft()
        {
            foreach (var r in _recipe.Resources)
            {
                ItemManager.Instance.Remove(r.Key, r.Value);
            }

            if (Recipe.Output == ItemType.Weapon)
            {
                var level = CraftingManager.Instance.ProgressWeaponRecipe();
                PlayerManager.Instance.ToggleWeapon(level);
                TutorialManager.Instance.Next(TutorialProgression.WaitingForMining);
            }
            else if (Recipe.Output == ItemType.RocketPart)
            {
                RocketManager.Instance.BuildPart(Recipe);
            }

            CheckCanCraft();
        }
    }
}
