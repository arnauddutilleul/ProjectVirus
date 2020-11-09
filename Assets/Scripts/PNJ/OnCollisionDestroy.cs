using UnityEngine;

namespace PNJ
{
    public class OnCollisionDestroy : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(other.rigidbody.gameObject);
            Destroy(this.gameObject);
        }
    
    }
}