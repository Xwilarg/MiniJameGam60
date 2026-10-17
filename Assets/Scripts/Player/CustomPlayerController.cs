using MiniJameGam.Craft;
using MiniJameGam.Item;
using Sketch.FPS;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MiniJameGam.Player
{
    public class CustomPlayerController : PlayerController
    {
        private Camera _cam;

        protected override void Awake()
        {
            base.Awake();

            _cam = Camera.main;
        }

        protected override void Update()
        {
            base.Update();

            if (RocketManager.Instance.IsShowingEnding)
            {
                _cam.transform.LookAt(RocketManager.Instance.BuildingTransform);
            }
        }

        public override bool IsActive => GameManager.Instance.CanMove;

        public override Vector2 GetCurrentInputRotation(Vector2 movInput)
        {
            return IsActive ? movInput : Vector2.zero;
        }

        public void OnAttack(InputAction.CallbackContext value)
        {
            if (value.phase == InputActionPhase.Started && GameManager.Instance.CanMove)
            {
                PlayerManager.Instance.Attack();
                var center = transform.position + _cam.transform.forward;
                var colls = Physics.OverlapSphere(center, .5f, LayerMask.GetMask("Item"));
                var target = colls.OrderBy(x => Vector3.Distance(center, x.transform.position)).FirstOrDefault();
                if (target != null)
                {
                    target.GetComponent<BreakableItem>().Hit(CraftingManager.Instance.Power);
                }
            }
        }
    }
}
