using UnityEngine;

namespace MiniJameGam.Progression
{
    public class TutorialManager : MonoBehaviour
    {
        public static TutorialManager Instance { private set; get; }

        private TutorialProgression _progression;

        private void Awake()
        {
            Instance = this;
        }

        public void Next(TutorialProgression next)
        {
            if (next - 1 == _progression)
            {
                _progression = next;
            }
        }
    }

    public enum TutorialProgression
    {
        WaitingForCraft,
        WaitingForMining,
        TutorialEnd
    }
}
