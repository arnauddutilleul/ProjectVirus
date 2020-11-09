using UnityEngine;
using UnityEngine.Events;

namespace Contamination
{
    public class Contamination : MonoBehaviour, IContamination
    {
        [SerializeField] private int currentContamination;
        [SerializeField] private int maxContamination;
        [SerializeField] private UnityEvent onDeath;
        [SerializeField] private UnityEvent damageSound;
        [SerializeField] private Animator animator;
        [SerializeField] private UnityEvent noLevelContamination;
        private static readonly int Die = Animator.StringToHash("Die");

        public void TakeContamination(int damage)
        {
            currentContamination += damage;
            if (currentContamination > maxContamination)
                currentContamination = maxContamination;
            
            damageSound?.Invoke();
            ContaminationManager.Instance.ModifyContamination(currentContamination);
            
            if (currentContamination == maxContamination)
            {
                //Death Animation
                //Block input of movement
                //Wait for the end of animation
                animator.SetTrigger(Die);
                onDeath?.Invoke();
            }
        }

        public bool Heal()
        {
            if (currentContamination > 0)
            {
                currentContamination -= 1;
                ContaminationManager.Instance.ModifyContamination(currentContamination);
                return true;
            }
            noLevelContamination?.Invoke();
            return false;
        }

    }
}