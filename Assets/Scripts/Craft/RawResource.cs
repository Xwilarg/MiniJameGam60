using MiniJameGam.Audio;
using MiniJameGam.Item;
using UnityEngine;

namespace MiniJameGam.Craft
{
    [RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
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
                _rb.linearVelocity = (Target.position - transform.position).normalized * 6f;
            }
        }

        private void Update()
        {
            if (Target != null && Vector2.Distance(new(Target.position.x, Target.position.z), new Vector2(transform.position.x, transform.position.z)) < .1f)
            {
                ItemManager.Instance.Add(Resource, 1);
                SoundsManager.Instance.PlayTakeResource();
                Destroy(gameObject);
            }
        }
    }
}
