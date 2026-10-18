using UnityEngine;

namespace MiniJameGam.Progression
{
    public class TimerManager : MonoBehaviour
    {
        public static TimerManager Instance { private set; get; }

        private float _timerRef;

        private void Awake()
        {
            _timerRef = Time.unscaledTime;
        }

        public float TimeElapsed => Time.unscaledTime - _timerRef;
    }
}
