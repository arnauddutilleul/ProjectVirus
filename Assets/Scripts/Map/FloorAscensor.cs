using UnityEngine;

public class FloorAscensor : MonoBehaviour
{
    private float _frontLimit;
    private float _bottomLimit;
    public float speed = 2.0f;
    private int _direction = 1;
    private Vector3 _movement;
    private Transform _transform;
    [SerializeField] private float maxFloor;
    [SerializeField] private bool goDown;


    private void Awake()
    {
        _transform = transform;
        var position = _transform.position;
        if (goDown)
        {
            _frontLimit = position.y + 0f;
            _bottomLimit = position.y - maxFloor;
        }
        else
        {
            _frontLimit = position.y + maxFloor;
            _bottomLimit = position.y - 0f;
        }
    }

    private void Update()
    {
        if (_transform.position.y > _frontLimit)
        {
            goDown = true;
        }
        else if (_transform.position.y < _bottomLimit)
        {
            goDown = false;
        }

        if (goDown)
        {
            _movement = Vector3.down * (speed * Time.deltaTime);
            _transform.Translate(_movement);
        }
        else
        {
            _movement = Vector3.up * (speed * Time.deltaTime);
            _transform.Translate(_movement);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.parent = this.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.parent = null;
    }
}