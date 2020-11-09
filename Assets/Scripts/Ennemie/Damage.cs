using UnityEngine;

namespace Ennemie
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int value;
        public LayerMask layerMask;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(layerMask == (layerMask | (1 <<other.gameObject.layer))) other.GetComponent<IDamageable>()?.TakeDamage(value);
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(layerMask == (layerMask | (1 <<other.gameObject.layer)))
                other.rigidbody.GetComponent<IDamageable>()?.TakeDamage(value);
        }

    }
}