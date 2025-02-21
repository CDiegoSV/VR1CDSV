using UnityEngine;

namespace Dante {
	public class Bullet : MonoBehaviour
	{
        public float speed = 20f;
        public float lifetime = 3f;

        private Rigidbody rb;
        private float timer;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void OnEnable()
        {
            timer = 0f;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        }

        void FixedUpdate()
        {
            timer += Time.fixedDeltaTime;

            if (timer >= lifetime)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
        }
    }
}
