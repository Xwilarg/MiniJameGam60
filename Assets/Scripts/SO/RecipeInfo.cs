using MiniJameGam.Item;
using System.Collections.Generic;
using UnityEngine;

namespace MiniJameGam.SO
{
    [CreateAssetMenu(menuName = "ScriptableObject/RecipeInfo", fileName = "RecipeInfo")]
    public class RecipeInfo : ScriptableObject
    {
        [SerializeField]
        public Dictionary<ResourceType, int> Resources;

        public string Name;

        public ItemType Output;

        public RecipeInfo NextRecipe;
    }

    public enum ItemType
    {
        Unknown,

        Weapon,
        RocketPart
    }
}
