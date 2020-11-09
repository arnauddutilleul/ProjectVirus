using UnityEngine;

namespace PickableAntidote
{
    public class Antidote : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.attachedRigidbody.GetComponent<IAntidote>()?.TakeAntidote();
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            other.rigidbody.GetComponent<IAntidote>()?.TakeAntidote();
        }

    }
}