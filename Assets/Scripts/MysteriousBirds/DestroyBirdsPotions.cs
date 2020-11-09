using UnityEngine;

public class DestroyBirdsPotions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hero") )
        {
            Destroy(this.gameObject);
        }

    }
}
