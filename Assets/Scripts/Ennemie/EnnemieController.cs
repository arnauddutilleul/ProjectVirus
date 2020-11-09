using System.Collections;
using UnityEngine;

namespace Ennemie
{
    public class EnnemieController : MonoBehaviour
    {
        [SerializeField] private Movement movement;
        [SerializeField] private Transform frontGroundCheck;
        [SerializeField] private int direction = 1;
        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private Transform detectAttack;
        private RaycastHit2D[] _results = new RaycastHit2D[1];
        private Transform _transform;
        private static readonly int attack = Animator.StringToHash("Attack");
        [SerializeField] private Animator _animatorEnnemie;

    


        private void Awake()
        {
            _transform = transform;
        
        }


        void Update()
        {
            if (Physics2D.RaycastNonAlloc(frontGroundCheck.position, Vector2.down, _results, 0.1f, groundLayers) > 0)
            {
                direction = -direction;
            }
        
            movement.Move(direction, 0);
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Hero")) AttackAnnimation(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Hero")) AttackAnnimation(false);
        }

        private void AttackAnnimation(bool condition)
        {
            _animatorEnnemie.SetBool(attack, condition);
        }
    
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            var position = frontGroundCheck.position;
            Gizmos.DrawLine(position, position + Vector3.down * 0.1f);
        
        
        }

        public void Death()
        {
        
            StartCoroutine("DeathCouroutine");

        }
    
        public IEnumerator DeathCouroutine()
        {
        
            yield return new WaitForSeconds(0.7f);
            transform.gameObject.SetActive(false);
        
        }
    
    }
}
