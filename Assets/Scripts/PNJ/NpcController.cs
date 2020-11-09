using UnityEngine;

namespace PNJ
{
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float fleeSpeed;
        [SerializeField] private Animator animator;

        public Animator Animator
        {
            get => animator;
        }
        
        private bool _canRun;

        public bool CanRun
        {
            set => _canRun = value;
        }
        
        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if(_canRun)
                Flee();
        }
        
        public void Flee()
        {
            var velocity = _rigidbody2D.velocity;
            velocity.x = 1 * fleeSpeed;
            _rigidbody2D.velocity = velocity;
        }
    }
}