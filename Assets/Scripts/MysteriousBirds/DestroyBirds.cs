using UnityEngine;


public class DestroyBirds : MonoBehaviour
{
    public bool isDestroy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Je rentre en colission");
        isDestroy = true;
        Destroy(other.attachedRigidbody.gameObject);
    }
}