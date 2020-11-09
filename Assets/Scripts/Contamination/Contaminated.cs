using UnityEngine;

namespace Contamination
{
    public class Contaminated : MonoBehaviour
    {
        [SerializeField] private int value;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Hero"))
                other.attachedRigidbody.GetComponent<IContamination>()?.TakeContamination(value);
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Hero"))
                other.rigidbody.GetComponent<IContamination>()?.TakeContamination(value);
        }

    }
}