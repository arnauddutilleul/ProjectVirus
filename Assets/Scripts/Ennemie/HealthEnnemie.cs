using UnityEngine;
using UnityEngine.Events;

namespace Ennemie{
    
    public class HealthEnnemie : MonoBehaviour, IDamageable
    {
        [SerializeField] private int vie;
        [SerializeField] private UnityEvent onDeath;
        private static readonly int death = Animator.StringToHash("Death");
        [SerializeField] private Animator animator;    

        public void TakeDamage(int damage)
        {

            

            vie -= damage;
            if (vie <= 0)
            {
                animator?.SetTrigger(death);
                onDeath?.Invoke();
            }
        }
    }
}
