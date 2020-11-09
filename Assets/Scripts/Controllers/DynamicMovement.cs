using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DynamicMovement : Movement
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private bool flipped;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private float maxGroundDistance = 0.1f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float jumpSpeed = 6;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isHero;
    private float _horizontal;
    private float _vertical;
    private bool _grounded;
    private bool _sit;
    private RaycastHit2D[] groundHits = new RaycastHit2D[1];
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private bool _jumping;
    private int _jump;
    [SerializeField] private bool inversed;
    private static int Speed;
    private static int SitAnimator;
    private static int JumpTrigger;
    private static int Grounded;

    public float getSpeed()
    {
        return horizontalSpeed;
    }

    public void setSpeed(float speed)
    {
        horizontalSpeed = speed;
    }
    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        
        Speed = Animator.StringToHash("Speed");
        SitAnimator = Animator.StringToHash("Sit");
        JumpTrigger = Animator.StringToHash("Jump");
        Grounded = Animator.StringToHash("Grounded");
    }

    public override void Move(float horizontal, float vertical)
    {
        _horizontal = horizontal;
        
        if (isHero)
            animator.SetFloat(Speed, Mathf.Abs(_horizontal));
        
        _vertical = vertical;
        if (inversed)
        {
            if (!((horizontal > 0 && flipped ) || ( horizontal < 0 && !flipped)))
                Flip();
        }
        else
        {
            if ((horizontal > 0 && flipped ) || ( horizontal < 0 && !flipped))
                Flip();
        }
        
    }

    public override void Jump()
    {
        _jump = CanJump() ? 1 : 0;
    }

    public override void Sit()
    {
        if (!_sit)
        {
            horizontalSpeed = horizontalSpeed / 2;
            animator.SetBool(SitAnimator, true);
            jumpSpeed = jumpSpeed / 2;
            _sit = true;
        }
        else
        {
            horizontalSpeed = horizontalSpeed * 2;
            jumpSpeed = jumpSpeed * 2;
            animator.SetBool(SitAnimator, false);
            _sit = false;
        }
    }

    private bool CanJump()
    {
        if (!_jumping && _grounded)
        {
            animator.SetTrigger(JumpTrigger);
            _jumping = true;
            return true;
        }
        return false;
    }

    private void CheckGround()
    {
        var wasGrounded = _grounded;
        _grounded = false;
        foreach (var check in groundChecks)
        {
            if (Physics2D.RaycastNonAlloc(check.position, Vector2.down, groundHits, maxGroundDistance, groundLayers) >
                0)
            {
                if (!_grounded)
                    _jumping = false;
                _grounded = true;
                break;
            }
        }
        if (wasGrounded != _grounded)
            animator.SetBool(Grounded, _grounded);
    }

    private void Flip(bool updateFlip = true)
    {
        
        flipped = updateFlip ? !flipped : flipped;
        var flipValue = flipped ? 180 : 0;
        _transform.localRotation = Quaternion.Euler(0, flipValue, 0);
       
    }

    private void FixedUpdate()
    {
        CheckGround();
        var velocity = _rigidbody.velocity;
        velocity.x = _horizontal * horizontalSpeed;
        if (_jump > 0)
        {
            velocity.y = jumpSpeed;
            _jump = 0;
        }
        _rigidbody.velocity = velocity;
    }

    private void OnValidate()
    {
        _transform = transform;
        Flip(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        foreach (var check in groundChecks)
        {
            var position = check.position;
            Gizmos.DrawLine(position, position + Vector3.down * maxGroundDistance);
        }
    }

    
}