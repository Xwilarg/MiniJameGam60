using MiniJameGam.Craft;
using UnityEngine;

namespace MiniJameGam.Player
{
    public class Vacuum : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<RawResource>(out var res))
            {
                res.Target = transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<RawResource>(out var res))
            {
                res.Target = null;
            }
        }
    }
}
