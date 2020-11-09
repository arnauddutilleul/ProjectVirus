using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float rightLimit = 2.5f;
    public float leftLimit = 1.0f;
    public float speed = 2.0f;
    private int direction = 1;
    private Vector3 movement;
    private Rigidbody2D rb;
    private Transform contact;
    [SerializeField] private float distance;
    [SerializeField] private bool inverted;

    private void Start()
    {
        if (inverted) direction = -direction;
           
        rightLimit = transform.position.x+ distance;
        leftLimit = transform.position.x - distance;
        
        
    }

    void Update () {
        if (transform.position.x > rightLimit) {
            direction = -1;
        }
        else if (transform.position.x < leftLimit) {
            direction = 1;
        }

        movement = Vector3.right * (direction * speed * Time.deltaTime); 
        transform.Translate(movement); 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.parent =this.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.parent=null;
    }
}
