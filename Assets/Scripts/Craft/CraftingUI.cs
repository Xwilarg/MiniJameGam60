using MiniJameGam.Item;
using MiniJameGam.SO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
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
            private get
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

        }
    }
}
