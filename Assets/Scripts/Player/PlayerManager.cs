using UnityEngine;

namespace MiniJameGam.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { private set; get; }

        [SerializeField]
        private GameObject[] _weapons;

        [SerializeField]
        private Animator _weaponAnim;

        private void Awake()
        {
            Instance = this;

            foreach (var w in _weapons) w.SetActive(false);
        }

        public void ToggleWeapon(int level)
        {
            if (level != 0) _weapons[level - 1].SetActive(false);
            _weapons[level].SetActive(true);
        }

        public void Attack()
        {
            _weaponAnim.SetTrigger("Swing");
        }
    }
}
