using UnityEngine;

namespace MiniJameGam.Audio
{
    public class SoundsManager : MonoBehaviour
    {
        public static SoundsManager Instance { private set; get; }

        [SerializeField]
        private AudioSource _hitSource;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayHit()
        {
            _hitSource.pitch = Random.Range(.8f, 1.2f);
            _hitSource.Play();
        }
    }
}
