using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MysteriousBirds : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] int maxDistance = 10;
    [SerializeField] private GameObject potionPrefabs;
    [SerializeField] private Transform potionSpwaner;
    [SerializeField] private LayerMask playerLayerMask;
    private RaycastHit2D[] _hits = new RaycastHit2D[1];
    private bool _detected = false;
    private Transform _transform;
    private Rigidbody2D _rigidbody;

    //private List<GameObject> spawnObject = new List<GameObject>();
    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        var velocity = _rigidbody.velocity;
        velocity.x = 1 * horizontalSpeed;
        _rigidbody.velocity = velocity;
        if (_detected == false)
        {
            PlayerDetectedDown();
        }
    }

    private void DropPotionItem()
    {
        Instantiate(potionPrefabs, potionSpwaner.position, Quaternion.identity);
    }

    private void PlayerDetectedDown()
    {
        if (Physics2D.RaycastNonAlloc(_transform.position, Vector2.down, _hits, maxDistance, playerLayerMask) >
            0)
        {
            _detected = true;
            DropPotionItem();
        }
    }
}