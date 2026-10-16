using MiniJameGam.Item;
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

                if (_progression == TutorialProgression.WaitingForMining)
                {
                    SpawnerManager.Instance.Spawn();
                }
                else if (_progression == TutorialProgression.TutorialEnd)
                {
                    SpawnerManager.Instance.StartAutoSpawn();
                }
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
