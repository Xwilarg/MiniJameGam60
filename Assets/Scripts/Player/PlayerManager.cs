using UnityEngine;

namespace MiniJameGam.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { private set; get; }

        [SerializeField]
        private GameObject _weapon;

        private void Awake()
        {
            Instance = this;

            _weapon.SetActive(false);
        }

        public bool IsWeaponActive => _weapon.activeInHierarchy;

        public void ToggleWeapon(bool value)
        {
            _weapon.SetActive(value);
        }
    }
}
