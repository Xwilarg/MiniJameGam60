using MiniJameGam.Item;
using UnityEngine;

namespace MiniJameGam.Craft
{
    public class RawResource : MonoBehaviour
    {
        public ResourceType Resource;

        private Rigidbody _rb;

        public Transform Target { set; get; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (Target != null)
            {
                _rb.linearVelocity = (Target.position - transform.position).normalized * 2f;
            }
        }

        private void Update()
        {
            if (Target != null && Vector3.Distance(Target.position, transform.position) < .1f)
            {
                ItemManager.Instance.Add(Resource, 1);
                Destroy(gameObject);
            }
        }
    }
}
