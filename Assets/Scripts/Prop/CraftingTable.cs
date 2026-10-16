using MiniJameGam.Craft;
using Sketch.FPS;
using UnityEngine;

namespace MiniJameGam.Prop
{
    public class CraftingTable : MonoBehaviour, IInteractable
    {
        public GameObject GameObject => gameObject;

        public bool CanInteract(PlayerController pc)
            => true;

        public string DenySentence(PlayerController pc)
            => null;

        public void Interact(PlayerController pc)
        {
            CraftingManager.Instance.OpenCraftingUI();
        }

        public string InteractionVerb(PlayerController pc)
            => null;
    }
}
