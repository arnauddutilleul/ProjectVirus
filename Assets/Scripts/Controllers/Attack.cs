using UnityEngine;

namespace Controllers
{
    public abstract class Attack : MonoBehaviour
    {
        public abstract void Lazer();
        public abstract void AttackEnnemyMelee();

        public abstract bool canAttackMelee();

    }
}
