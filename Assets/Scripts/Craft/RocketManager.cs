using MiniJameGam.SO;
using System.Linq;
using UnityEngine;

namespace MiniJameGam.Craft
{
    public class RocketManager : MonoBehaviour
    {
        public static RocketManager Instance { private set; get; }

        [SerializeField]
        private RocketPart[] _parts;

        [SerializeField]
        private Transform _buildingTransform;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CraftingManager.Instance.AddRecipes(_parts.Select(x => x.Recipe));
        }

        public void BuildPart(RecipeInfo recipe)
        {
            var part = _parts.First(x => x.Recipe.GetEntityId() == recipe.GetEntityId());

            CraftingManager.Instance.RemoveRecipe(recipe.GetEntityId());
            Destroy(part.Blueprint);
            var go = Instantiate(part.Prefab, _buildingTransform);
            go.transform.localPosition = Vector3.zero;
        }
    }

    [System.Serializable]
    public class RocketPart
    {
        public RecipeInfo Recipe;
        public GameObject Blueprint;
        public GameObject Prefab;
    }
}
