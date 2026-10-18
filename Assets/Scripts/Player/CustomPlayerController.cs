using MiniJameGam.Audio;
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
        [SerializeField]
        private GameObject _hitEffect;

        private Vector3 _basePos;
        private CharacterController _playerCC;

        private Camera _cam;

        protected override void Awake()
        {
            base.Awake();

            _cam = Camera.main;
            _playerCC = GetComponent<CharacterController>();
            _basePos = transform.position;
        }

        protected override void Update()
        {
            base.Update();

            if (RocketManager.Instance.IsShowingEnding)
            {
                _cam.transform.LookAt(RocketManager.Instance.BuildingTransform);
            }

            if (transform.position.y < -10f)
            {
                _playerCC.enabled = false;
                transform.position = _basePos;
                _playerCC.enabled = true;
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
                    Vector3 pos = target.transform.position;
                    if (Physics.Linecast(_cam.transform.position, target.transform.position, out var hit, LayerMask.GetMask("Item")))
                    {
                        pos = hit.point;
                    }
                    SoundsManager.Instance.PlayHit();
                    var vfx = Instantiate(_hitEffect, pos, Quaternion.identity);
                    var mats = target.GetComponent<MeshRenderer>().materials;
                    vfx.GetComponent<ParticleSystemRenderer>().sharedMaterial = mats[Random.Range(0, mats.Length)];
                    Destroy(vfx, 1f);
                }
            }
        }

        public void OnCancel(InputAction.CallbackContext value)
        {
            if (value.phase == InputActionPhase.Started)
            {
                if (CraftingManager.Instance.IsActive)
                {
                    CraftingManager.Instance.CloseCraftingUI();
                }
            }
        }
    }
}
