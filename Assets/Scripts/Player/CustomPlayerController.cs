using MiniJameGam.Craft;
using MiniJameGam.Item;
using Sketch.FPS;
using UnityEngine;

namespace MiniJameGam.Player
{
    public class CustomPlayerController : PlayerController
    {
        public override bool IsActive => GameManager.Instance.CanMove;

        public override Vector2 GetCurrentInputRotation(Vector2 movInput)
        {
            return IsActive ? movInput : Vector2.zero;
        }
    }
}
