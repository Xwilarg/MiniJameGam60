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

        private int _partsBuilt = 0;

        [SerializeField]
        private Transform _buildingTransform;
        public Transform BuildingTransform => _buildingTransform;

        [SerializeField]
        private Animator _rocketAnim;

        [SerializeField]
        private GameObject _thanksForPlaying;

        public bool IsShowingEnding { private set; get; }

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
            _partsBuilt++;

            if (_partsBuilt == _parts.Length)
            {
                StartRocket();
                _thanksForPlaying.SetActive(true);
            }
        }

        public void StartRocket()
        {
            CraftingManager.Instance.CloseCraftingUI();
            IsShowingEnding = true;
            _rocketAnim.SetTrigger("Go");
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
